var passport = require('passport');

module.exports = {
    login: function(req, res, next) {
        var auth = passport.authenticate('local', function(err, user) {

            if (err) {
                req.session.error = 'Invalid Password/Username!';
                return next(err);
            }

            if (!user) {
                req.session.error = 'Invalid Password/Username!';
                res.redirect('/login');
            }

            req.logIn(user, function(err) {
                if (err) return next(err);
                res.redirect('/');
            })
        });

        auth(req, res, next);
    },
    logout: function(req, res, next) {
        req.logout();
        res.redirect('/');
    },
    isAuthenticated: function(req, res, next) {
        if (!req.isAuthenticated()) {
            req.session.error = 'You mast be login to have access!';
            res.redirect('/login');
        }
        else {
            next();
        }
    }
};