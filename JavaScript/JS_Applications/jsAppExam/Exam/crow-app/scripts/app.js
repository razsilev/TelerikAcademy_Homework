/// <reference path="libs/jquery-2.0.2.js" />
/// <reference path="libs/handlebars-v1.3.0.js" />
/// <reference path="module-for-http-requests.js" />
/// <reference path="require-js-2-1-14.js" />
(function () {
    require.config({
        paths: {
            'handlebars': 'scripts/libs/handlebars-v1.3.0',
            'jquery': 'scripts/libs/jquery-2.0.2',
            'q': 'scripts/libs/q',
            'httpRequest': 'scripts/module-for-http-requests',
            'underscore': 'underscore'
        }
    });

    require(['httpRequest', 'jquery', 'handlebars'], function (httpRequest) {
        var MAX_POSTS_COUNT = 30,
            userName = 'me',
            url = 'http://jsapps.bgcoder.com/', // base url paste!!! methods add resurce '.com/post'
            templateString = $('#item-template').html(),
            template = Handlebars.compile(templateString),
            $sendPostBtn = $('#send'),
            $postText = $('#user-text'),
            $ul = $('#posts-container'),
            $titleItem = $('#title-input'), // <- element to get post title
            // user parameters
            $userName = $('#user-name'),
            $password = $('#password'),
            // autentications and registration buttons
            $registerBtn = $('#register-btn'),
            $loginBtn = $('#login-btn'),
            $logoutBtn = $('#logout-btn'),
            // page shange button
            pageBtn = document.createElement('a'),
            $pagesLinksContainer = $('#pages-links-container'),
            // sort setings
            isAscedenting = true,
            isSortByTitle = true,
            postPerPage = 2,
            $postsPerPageInput = $('#get-posts-per-page'),
            $postsNumberLabel = $('#posts-number'),
            $sortBtn = $('#sortbtn'),
            loginObj = {};

        pageBtn.href = '#';

        // set post per page
        $postsPerPageInput.val(postPerPage);
        $postsNumberLabel.html(postPerPage);

        $postsPerPageInput.on('keyup', function () {
            var number = Math.floor($postsPerPageInput.val() * 1);

            if (number > 0) {
                postPerPage = number;
                $postsNumberLabel.html(number);
                addPostsToHtml();
            }

        });

        $sortBtn.on('click', function () {

            if ($('#descedenting').is(':checked')) {
                isAscedenting = false;
            } else {
                isAscedenting = true;
            }

            if ($('#date').is(':checked')) {
                isSortByTitle = false;
            } else {
                isSortByTitle = true;
            }

            addPostsToHtml();
        });

        function addPostsToHtml() {
            httpRequest.getJSON(url + 'post').then(function (posts) {
                var postsToViewOnPage = [],
                    start = 0,
                    i,
                    elementsPerPage = postPerPage,
                    fragment = document.createDocumentFragment(),
                    pageNumber = 0,
                    currentPageBtn,
                    pages = [];

                //console.log(posts);
                posts.sort(sort);


                // generate peges
                for (i = start; i < posts.length; i += 1) {
                    postsToViewOnPage.push(posts[i]);

                    if (postsToViewOnPage.length === elementsPerPage || (posts.length - 1) === i) {
                        pages.push(postsToViewOnPage);
                        postsToViewOnPage = [];

                        currentPageBtn = pageBtn.cloneNode(true);
                        currentPageBtn.innerHTML = pageNumber;

                        currentPageBtn.addEventListener('click', function (ev) {
                            loadPage(ev.currentTarget.innerHTML * 1, pages);
                        });

                        fragment.appendChild(currentPageBtn);

                        pageNumber += 1;
                    }
                }

                $pagesLinksContainer.find('a').remove();
                $pagesLinksContainer.append(fragment);

                loadPage(0, pages);
            });
        }

        function loadPage(pageNumber, pages) {
            var postsToView = pages[pageNumber];


            $ul.children().remove();

            $ul.append(template({ posts: postsToView }));
        }

        function sort(a, b) {

            if (isSortByTitle) {

                if (isAscedenting) {
                    if (a.title.toLowerCase() > b.title.toLowerCase()) {
                        return 1;
                    }
                    return -1;
                } else {
                    if (a.title.toLowerCase() < b.title.toLowerCase()) {
                        return 1;
                    }
                    return -1;
                }
            } else {
                if (isAscedenting) {
                    if (a.postDate.toLowerCase() > b.postDate.toLowerCase()) {
                        return 1;
                    }
                    return -1;
                } else {
                    if (a.postDate.toLowerCase() < b.postDate.toLowerCase()) {
                        return 1;
                    }
                    return -1;
                }
            }
        }

        addPostsToHtml();

        // register user
        $registerBtn.on('click', function () {
            var post,
                name,
                password,
                authCode;

            name = $userName.val();
            password = $password.val();
            authCode = name + password + name + password;

            authCode += 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa';

            authCode = authCode.substr(0, 40);

            post = {
                username: name,
                authCode: authCode
            };

            httpRequest.postJSON(url + 'user', post).then(function (data) {
                alert('ures is REGISTERED');
            }, function (error) {
                // {"Message":"Username already exists","errCode":"ERR_DUP_USR"}
                alert(error.message);
            });

        });

        // login user
        $loginBtn.on('click', function () {
            var post,
                name,
                password,
                authCode;

            name = $userName.val();
            password = $password.val();
            authCode = name + password + name + password;

            authCode += 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa';

            authCode = authCode.substr(0, 40);

            post = {
                username: name,
                authCode: authCode
            };

            httpRequest.postJSON(url + 'auth', post).then(function (data) {
                loginObj = data;
                $('#login-user').html(data.username);

            }, function (error) {
                // {"Message":"Username already exists","errCode":"ERR_DUP_USR"}
                alert(error.message);
            });

        });

        // logout user
        $logoutBtn.on('click', function () {
            var post;

            post = {
                url: url + 'user',
                headers: { 'X-SessionKey': loginObj.sessionKey },
                type: 'PUT'
            };

            $.ajax(post).then(function (data) {
                $('#login-user').html('');

            }, function (error) {
                // {"Message":"Username already exists","errCode":"ERR_DUP_USR"}
                alert(error.message);
            });

        });

        // public post
        $sendPostBtn.on('click', function () {
            var text = $postText.val(),
                post,
                option,
                title;

            title = $titleItem.val() || 'no title';

            // make ajax
            option = {
                url: url + 'post',
                type: 'POST',
                data: {
                    body: text,
                    title: title
                },
                headers: { 'X-SessionKey': loginObj.sessionKey }
            };

            $.ajax(option).success(function () {
                addPostsToHtml();

                $('#post-send').show().css('color', 'green').fadeOut(2500);

            }).error(function (error) {
                // {"Message":"Username already exists","errCode":"ERR_DUP_USR"}
                alert('ERROR: ' + error.responseJSON.message);
                console.dir(error);
            });

        });
    });
}());