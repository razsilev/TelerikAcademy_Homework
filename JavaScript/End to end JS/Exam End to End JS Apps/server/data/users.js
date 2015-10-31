var User = require('mongoose').model('User');

module.exports = {
    create: function(user, callback) {
        User.create(user, callback);
    },
    update: function(user, newUserData, callback) {

        User.findById(user._id, function (err, userDb) {
            if (err) {
                callback(err);
            }

            userDb.phoneNumber = newUserData.phoneNumber;
            userDb.facebook = newUserData.facebook;
            userDb.twitter = newUserData.twitter;
            userDb.linkedIn = newUserData.linkedIn;
            userDb.google = newUserData.google;

            userDb.save(callback);
        });
    }
};