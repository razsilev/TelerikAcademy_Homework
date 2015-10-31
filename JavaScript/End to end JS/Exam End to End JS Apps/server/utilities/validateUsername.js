module.exports = function(userData) {

    var name = userData.username;

    if (name.length < 6 || 20 < name.length) {
        return false;
    }

    var validSymbols = 'qwertyuiopasdfghjklzxcvbnm1234567890_ .';
    name = name.toLowerCase();

    for (var i = 0; i < name.length; i += 1){
        if (validSymbols.indexOf(name[i]) < 0) {
            return false;
        }
    }

    return true;
};
