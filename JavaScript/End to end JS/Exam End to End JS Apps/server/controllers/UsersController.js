var encryption = require('../utilities/encryption'),
    isValidUserName = require('../utilities/validateUsername'),
    users = require('../data/users');

var CONTROLLER_NAME = 'users';

module.exports = {
    getRegister: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/register')
    },
    postRegister: function(req, res, next) {
        var newUserData = req.body;

        if (newUserData.password != newUserData.confirmPassword) {
            req.session.error = 'Passwords do not match!';
            res.redirect('/register');
        }
        else if (!isValidUserName(newUserData)){
            req.session.error = 'The username: ' + newUserData.username + ' is INVALID!';
            res.redirect('/register');
        }
        else {
            newUserData.salt = encryption.generateSalt();
            newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);
            users.create(newUserData, function(err, user) {
                if (err) {
                    console.log('Failed to register new user: ' + err);
                    req.session.error = 'Invalid or missing form data!';
                    return;
                }

                req.logIn(user, function(err) {
                    if (err) {
                        req.session.error = 'Invalid Password/Username!';
                        return res;
                    }
                    else {
                        res.redirect('/');
                    }
                })
            });
        }
    },
    getLogin: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/login');
    },
    getProfile: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/profile', {currentUser: req.user});
    },
    postProfile: function(req, res, next) {
        var newUserData = req.body;

        users.update(req.user, newUserData, function(err) {
            if (err) {
                console.log('Edit profile db error: ' + err);
                req.session.error = 'Something bad happens!';
            }

            res.redirect('/profile');
        });
    }
};