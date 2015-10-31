var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption');

module.exports.init = function() {
    var userSchema = mongoose.Schema({
        username: { type: String, required: '{PATH} is required', unique: true },
        salt: String,
        hashPass: String,
        eventsPoints: Number,
        firstName: {type: String, required: '{PATH} is required'},
        lastName: {type: String, required: '{PATH} is required'},
        phoneNumber: String,
        email: {type: String, required: '{PATH} is required'},
        initiatives: [{
            initiative: String,
            season: Number
        }],
        imagePath: String,
        facebook: String,
        twitter: String,
        linkedIn: String,
        google: String
    });

    userSchema.method({
        authenticate: function(password) {
            if (encryption.generateHashedPassword(this.salt, password) === this.hashPass) {
                return true;
            }
            else {
                return false;
            }
        }
    });

    var User = mongoose.model('User', userSchema);
};
