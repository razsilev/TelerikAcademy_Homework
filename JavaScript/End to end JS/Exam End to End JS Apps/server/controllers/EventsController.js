var events = require('../data/events')
users = require('../data/users');

var CONTROLLER_NAME = 'events';

module.exports = {
    getEvent: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/event', {currentUser: req.user})
    },
    postEvent: function (req, res, next) {
        var newEventData = req.body;

        events.create(newEventData, function (err, event) {
            if (err) {
                console.log('Failed to create event: ' + err);
                req.session.error = 'Can not create event!';

                return res;
            }
            else {
                res.redirect('/');
            }
        });
    }
};