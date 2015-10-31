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
            'httpRequest': 'scripts/module-for-http-requests'
        }
    });

    require(['httpRequest', 'jquery', 'handlebars'], function (httpRequest) {
        var MAX_POSTS_COUNT = 30,
            userName = 'me',
            url = 'http://crowd-chat.herokuapp.com/posts',
            templateString = $('#item-template').html(),
            template = Handlebars.compile(templateString),
            $sendPostBtn = $('#send'),
            $postText = $('#user-text'),
            $ul = $('#posts-container'),
            $userNameInput = $('#input-name'),
            $usernameShow = $('#user-name'),
            $setNameBtn = $('#set-name-btn');

        $usernameShow.text(userName);

        $setNameBtn.on('click', function () {
            var name = $userNameInput.val();

            if (name !== '') {
                userName = name;
                $usernameShow.text(userName);
            }
        });

        function addPostsToHtml() {
            httpRequest.getJSON(url).then(function (posts) {
                var postsToView = [],
                    start = 0,
                    i;

                if (posts.length > MAX_POSTS_COUNT) {
                    start = posts.length - MAX_POSTS_COUNT;
                }

                for (i = start; i < posts.length; i += 1) {
                    postsToView.push(posts[i]);
                }

                $ul.children().remove();

                $ul.append(template({ posts: postsToView }));
            });
        }

        addPostsToHtml();

        //setInterval(function () {
        //    addPostsToHtml();
        //}, 3000);

        $sendPostBtn.on('click', function () {
            var text = $postText.val(),
                post;

            post = {
                text: text,
                user: userName
            };

            httpRequest.postJSON(url, post).then(function () {
                addPostsToHtml();
            });
        });
    });
}());