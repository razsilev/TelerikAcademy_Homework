var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function(app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.isAuthenticated, auth.logout);

    app.get('/profile', auth.isAuthenticated, controllers.users.getProfile);
    app.post('/profile', auth.isAuthenticated, controllers.users.postProfile);

    app.get('/create-event', auth.isAuthenticated, controllers.events.getEvent);
    app.post('/create-event', auth.isAuthenticated, controllers.events.getEvent);

    app.get('/', function(req, res) {
        res.render('index', {currentUser: req.user});
    });

    app.get('*', function(req, res) {
        res.render('index', {currentUser: req.user});
    });
};