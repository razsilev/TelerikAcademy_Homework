/// <reference path="libs/underscore.js" />
(function () {
    var books = [{
        header: 'Microsoft SQL Server 2012 Step by Step',
        author: 'Patrick LeBlanc'
    }, {
        header: 'Windows PowerShell 3.0 First Steps',
        author: 'Ed Wilson'
    }, {
        header: 'Node.js, MongoDB, and AngularJS Web Development',
        author: 'Brad Dayley'
    }, {
        header: 'Windows Azure Developers',
        author: 'Bruce Johnson'
    }, {
        header: 'Code Complete',
        author: 'Steve McConnell'
    }, {
        header: 'Refactoring',
        author: 'John Brant'
    }, {
        header: 'Professional Visual Studio 2013',
        author: 'Bruce Johnson'
    }, {
        header: 'Professional Software Development',
        author: 'Steve McConnell'
    }, {
        header: 'jQuery and JavaScript Phrasebook',
        author: 'Brad Dayley'
    }, {
        header: 'NoSQL with MongoDB in 24 Hours, Sams Teach Yourself',
        author: 'Brad Dayley'
    }],
        author;

    console.log('-------- Origin: ---------');
    _.each(books, function (book) {
        console.log(book.author + ' -> ' +
                    book.header);
    });

    function findMostPopularAuthor(books) {
        var groupedBooks,
            groupWithMaxLength;

        groupedBooks = _.groupBy(books, function (book) {
            return book.author;
        });

        groupWithMaxLength = _.max(groupedBooks, function (groupe) {
            return groupe.length;
        });

        return groupWithMaxLength[0].author;
    }

    author = findMostPopularAuthor(books);

    console.log('\n-------- Result: ---------');
    console.log('Most popular author is: ' + author);
}());