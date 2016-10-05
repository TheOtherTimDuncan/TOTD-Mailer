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

        console.error.called.should.be.equal(true, 'console.error should be called');
        queueService.createQueueIfNotExists.called.should.be.equal(true, 'createQueueIfNotExists should be called');
        callback.called.should.be.equal(false, 'callback should not be called');

    });

    it('should call callback if queue created', function () {

        var queueService = {
            createQueueIfNotExists: sinon.stub().yields(null)
        };

        var callback = sinon.stub();
        app.createQueue(queueService, 'test', callback);

        console.error.called.should.be.equal(false, 'console.error should not be called');
        queueService.createQueueIfNotExists.called.should.be.equal(true, 'createQueueIfNotExists should be called');
        callback.calledWith('test').should.be.equal(true, 'callback should be called');

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

        console.error.called.should.be.equal(true, 'console.error should be called');
        queueService.getMessages.called.should.be.equal(true, 'getMessages should be called');
        callback.called.should.be.equal(false, 'callback should not be called');

    });

    it('should call callback if message retrieved from queue', function () {

        var message = [
            {
                messagetext: 'message'
            }
        ];

        var queueService = {
            getMessages: sinon.stub().yields(null, message)
        };

        var callback = sinon.stub();
        app.getMessage(queueService, 'test', callback);

        console.error.called.should.be.equal(false, 'console.error should not be called');
        queueService.getMessages.called.should.be.equal(true, 'getMessages should be called');
        callback.calledWith(message[0], message[0].messagetext).should.be.equal(true, 'callback should be called');

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

        console.error.called.should.be.equal(true, 'console.error should be called');
        queueService.deleteMessage.called.should.be.equal(true, 'deleteMessage should be called');
        callback.called.should.be.equal(false, 'callback should not be called');

    });

    it('should call callback if message deleted from queue', function () {

        var queueService = {
            deleteMessage: sinon.stub().yields(null)
        };

        var callback = sinon.stub();
        var messageText = 'message';

        app.deleteMessage(queueService, 'test', {}, messageText, callback);

        console.error.called.should.be.equal(false, 'console.error should not be called');
        queueService.deleteMessage.called.should.be.equal(true, 'deleteMessage should be called');
        callback.calledWith(messageText).should.be.equal(true, 'callback should be called');

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
            "to": "to@to.com",
            "from": "from@from.com",
            "subject": "subject",
            "text": "text"
        };

        var messageText = JSON.stringify(message);

        var sendgrid = {
            Email: sinon.stub(),
            send: sinon.stub().yields(null)
        };

        app.sendEmail({}, 'test', sendgrid, messageText);

        sendgrid.send.called.should.be.equal(true, 'sendgrid.send should be called');
        sendgrid.Email.called.should.be.equal(true, 'sendgrid.Email should be called');
        console.error.called.should.be.equal(false, 'console.error should not be called');
        console.log.called.should.be.equal(true, 'console.log should be called');
    });

    it('should add message back to queue if email failed', function () {

        var message = {
            "to": "to@to.com",
            "from": "from@from.com",
            "subject": "subject",
            "text": "text"
        };

        var messageText = JSON.stringify(message);

        var sendgrid = {
            Email: sinon.stub(),
            send: sinon.stub().yields('error')
        };

        var queueService = {
            createMessage: sinon.stub().yields(null)
        };

        app.sendEmail(queueService, 'test', sendgrid, messageText);

        sendgrid.send.called.should.be.equal(true, 'sendgrid.send should be called');
        sendgrid.Email.called.should.be.equal(true, 'sendgrid.Email should be called');
        console.error.called.should.be.equal(true, 'console.error should be called');
        console.log.called.should.be.equal(true, 'console.log should be called');
    });
});

describe('buildEmail', function () {
    it ('should build email from template', function () {
        app.buildEmail(handlebars, '<p>{{ name }}</p>', { "name": "test" });
    }); 
});