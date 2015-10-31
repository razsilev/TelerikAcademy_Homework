var mongoose = require('mongoose');

module.exports.init = function() {
    var eventSchema = mongoose.Schema({
        title: { type: String, required: '{PATH} is required'},
        description: { type: String, required: '{PATH} is required'},
        category: { type: String, required: '{PATH} is required'},
        type: [{
            initiative: { type: String, required: '{PATH} is required', enum: ['Software Academy', 'Algo Academy', 'School Academy'] },
            season: { type: String, required: '{PATH} is required'}
        }],
        creatorsNames: [],
        phoneNumber: { type: String, required: '{PATH} is required'},
        comments: [],
        location: String
    });

    var Event = mongoose.model('Event', eventSchema);
};