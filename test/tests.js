var should = require('should');
var sinon = require('sinon');

var handlebars = require('handlebars');

var app = require('../lib/app.js');

describe('createQueue', function () {

    beforeEach(function () {
        sinon.spy(console, 'log');
        sinon.spy(console, 'error');
    });

    afterEach(function () {
        console.log.restore();
        console.error.restore();
    });

    it('should log error and stop if cannot create queue', function () {

        var queueService = {
            createQueueIfNotExists: sinon.stub().yields('error')
        };

        var callback = sinon.stub();
        app.createQueue(queueService, 'test', callback);

        console.error.called.should.be.true('console.error should be called');
        queueService.createQueueIfNotExists.called.should.be.true('createQueueIfNotExists should be called');
        callback.called.should.be.false('callback should not be called');

    });

    it('should call callback if queue created', function () {

        var queueService = {
            createQueueIfNotExists: sinon.stub().yields()
        };

        var callback = sinon.stub();
        app.createQueue(queueService, 'test', callback);

        console.error.called.should.be.false('console.error should not be called');
        queueService.createQueueIfNotExists.called.should.be.true('createQueueIfNotExists should be called');
        callback.called.should.be.true('callback should be called');

    });

});

describe('getMessage', function () {

    beforeEach(function () {
        sinon.spy(console, 'log');
        sinon.spy(console, 'error');
    });

    afterEach(function () {
        console.log.restore();
        console.error.restore();
    });

    it('should log error and stop if cannot get message from queue', function () {

        var queueService = {
            getMessages: sinon.stub().yields('error')
        };

        var callback = sinon.stub();
        app.getMessage(queueService, 'test', callback);

        console.error.called.should.be.true('console.error should be called');
        queueService.getMessages.called.should.be.true('getMessages should be called');
        callback.called.should.be.false('callback should not be called');

    });

    it('should call callback if message retrieved from queue', function () {

        var messageText = 'message';

        var message = [
            {
                messageText: new Buffer(messageText).toString('base64')
            }
        ];

        var queueService = {
            getMessages: sinon.stub().yields(null, message)
        };

        var callback = sinon.stub();
        app.getMessage(queueService, 'test', callback);

        console.error.called.should.be.false('console.error should not be called');
        queueService.getMessages.called.should.be.true('getMessages should be called');
        callback.calledWith(message[0], messageText).should.be.true('callback should be called');

    });

});

describe('deleteMessage', function () {

    beforeEach(function () {
        sinon.spy(console, 'log');
        sinon.spy(console, 'error');
    });

    afterEach(function () {
        console.log.restore();
        console.error.restore();
    });

    it('should log error and stop if cannot delete message from queue', function () {

        var queueService = {
            deleteMessage: sinon.stub().yields('error')
        };

        var callback = sinon.stub();
        app.deleteMessage(queueService, 'test', {}, 'message', callback);

        console.error.called.should.be.true('console.error should be called');
        queueService.deleteMessage.called.should.be.true('deleteMessage should be called');
        callback.called.should.be.false('callback should not be called');

    });

    it('should call callback if message deleted from queue', function () {

        var queueService = {
            deleteMessage: sinon.stub().yields()
        };

        var callback = sinon.stub();
        var messageText = 'message';

        app.deleteMessage(queueService, 'test', {}, messageText, callback);

        console.error.called.should.be.false('console.error should not be called');
        queueService.deleteMessage.called.should.be.true('deleteMessage should be called');
        callback.called.should.be.true('callback should be called');

    });

});

describe('sendEmail', function () {

    beforeEach(function () {
        sinon.spy(console, 'log');
        sinon.spy(console, 'error');
    });

    afterEach(function () {
        console.log.restore();
        console.error.restore();
    });

    it('should send email using message from queue', function () {

        var message = {
            "to": ["to@to.com"],
            "from": "from@from.com",
            "subjectTemplate": "subject",
            "textTemplate": "text",
            "htmlTemplate": "<p>text<p>",
            "emailData": "emailData"
        };

        var messageText = JSON.stringify(message);

        var request = {};
        var response = {};
        var html = 'html';
        var subject = 'subject';
        var txt = 'txt';

        var queueService = {
            createMessage: sinon.stub()
        };

        var sendgrid = {
            Email: sinon.stub(),
            emptyRequest: sinon.stub().returns(request),
            API: sinon.stub().yields(null, response)
        };

        var stubSubjectTemplate = sinon.stub().returns(subject);
        var stubHtmlTemplate = sinon.stub().returns(html);
        var stubTxtTemplate = sinon.stub().returns(txt);

        var stubCompile = sinon.stub();
        stubCompile.withArgs(message.subjectTemplate).returns(stubSubjectTemplate);
        stubCompile.withArgs(message.htmlTemplate).returns(stubHtmlTemplate);
        stubCompile.withArgs(message.textTemplate).returns(stubTxtTemplate);

        var hb = {
            compile: stubCompile
        };

        var stubAddTo = sinon.stub();
        var stubToJson = sinon.stub();
        var stubAddContent = sinon.stub();

        var sendgridEmail = {
            Email: sinon.stub(),
            Content: sinon.stub(),
            Mail: sinon.stub().returns({
                toJSON: stubToJson,
                addContent: stubAddContent,
                personalizations: [{ addTo: stubAddTo }]
            })
        };

        app.sendEmail(queueService, 'test', sendgrid, sendgridEmail, hb, messageText);

        stubHtmlTemplate.calledWith(message.emailData).should.be.true();
        stubSubjectTemplate.calledWith(message.emailData).should.be.true();
        stubTxtTemplate.calledWith(message.emailData).should.be.true();

        sendgridEmail.Email.calledWith(message.from).should.be.true();
        sendgridEmail.Email.calledWith(message.to[0]).should.be.true();
        sendgridEmail.Content.calledWith('text/html', html).should.be.true();
        sendgridEmail.Content.calledWith('text/plain', txt).should.be.true();

    });

    it('should add message back to queue if email failed', function () {

        var message = {
            "to": "to@to.com",
            "from": "from@from.com",
            "subject": "subject",
            "textTemplate": "text",
            "htmlTemplate": "<p>text<p>"
        };

        var messageText = JSON.stringify(message);

        var request = {};
        var response = {};

        var sendgrid = {
            Email: sinon.stub(),
            emptyRequest: sinon.stub().returns(request),
            API: sinon.stub().yields(null, response)
        };

        var stubCompile = sinon.stub();
        var hb = {
            compile: sinon.stub().returns(stubCompile)
        };

        var stubAddTo = sinon.stub();
        var stubToJson = sinon.stub();

        var sendgridEmail = {
            Email: stubCompile,
            Content: sinon.stub(),
            Mail: sinon.stub().returns({
                toJSON: stubToJson,
                personalizations: [{ addTo: stubAddTo }]
            })
        };

        var queueService = {
            createMessage: sinon.stub()
        };

        app.sendEmail(queueService, 'test', sendgrid, sendgridEmail, hb, messageText);

        // sendgrid.send.called.should.be.equal(true, 'sendgrid.send should be called');
        // sendgrid.Email.called.should.be.equal(true, 'sendgrid.Email should be called');
        // console.error.called.should.be.equal(true, 'console.error should be called');
        // console.log.called.should.be.equal(true, 'console.log should be called');
    });
});

describe('buildEmail', function () {
    it('should build email from template', function () {
        app.buildEmail(handlebars, '<p>{{ name }}</p>', { "name": "test" });
    });
});