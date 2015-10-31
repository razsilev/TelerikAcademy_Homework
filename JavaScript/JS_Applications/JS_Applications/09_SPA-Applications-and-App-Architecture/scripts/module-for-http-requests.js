/// <reference path="libs/require-js-2-1-14.js" />
/// <reference path="q.js" />
define(['q'] ,function (Q) {
    httpRequest = (function () {
        var getHttpRequest, getJSON, makeRequest, postJSON;
        getHttpRequest = (function () {
            var xmlHttpFactories;
            xmlHttpFactories = [

              function () {
                  return new XMLHttpRequest();
              },
              function () {
                  return new ActiveXObject("Msxml3.XMLHTTP");
              },
              function () {
                  return new ActiveXObject("Msxml2.XMLHTTP.6.0");
              },
              function () {
                  return new ActiveXObject("Msxml2.XMLHTTP.3.0");
              },
              function () {
                  return new ActiveXObject("Msxml2.XMLHTTP");
              },
              function () {
                  return new ActiveXObject("Microsoft.XMLHTTP");
              }
            ];
            return function () {
                var xmlFactory, _i, _len;
                for (_i = 0, _len = xmlHttpFactories.length; _i < _len; _i++) {
                    xmlFactory = xmlHttpFactories[_i];
                    try {
                        return xmlFactory();
                    } catch (_error) {

                    }
                }
                return null;
            };
        })();

        makeRequest = function (options) {
            var httpRequest, requestUrl, type, success, error, contentType, accept, data;
            httpRequest = getHttpRequest();
            options = options || {};
            //extract the values from the options and provide default values for the missing arguments
            requestUrl = options.url;
            type = options.type || 'GET';
            success = options.success || function () { };
            error = options.error || function () { };
            contentType = options.contentType || '';
            accept = options.accept || '';
            data = options.data || null;

            httpRequest.onreadystatechange = function () {
                if (httpRequest.readyState === 4) {
                    switch (Math.floor(httpRequest.status / 100)) {
                        case 2:
                            success(httpRequest.responseText);
                            break;
                        default:
                            error(httpRequest.responseText);
                            break;
                    }
                }
            };
            httpRequest.open(type, requestUrl, true);
            httpRequest.setRequestHeader('Content-Type', contentType);
            httpRequest.setRequestHeader('Accept', accept);
            return httpRequest.send(data);
        };

        getJSON = function (url) {
            var deferred = Q.defer(),
                options = {
                    url: url,
                    type: 'GET',
                    contentType: 'application/json',
                    accept: 'application/json',
                    success: function (data) {
                        if (data) {
                            deferred.resolve(JSON.parse(data));
                        }
                    },
                    error: function (err) {
                        if (err) {
                            deferred.reject(JSON.parse(err));
                        }
                    }
                };

            makeRequest(options);

            return deferred.promise;
        };

        postJSON = function (url, data) {
            var deferred = Q.defer(),
                options = {
                    url: url,
                    type: 'POST',
                    contentType: 'application/json',
                    accept: 'application/json',
                    data: JSON.stringify(data),
                    success: function (data) {
                        if (data) {
                            deferred.resolve(JSON.parse(data));
                        }
                    },
                    error: function (err) {
                        if (err) {
                            deferred.reject(JSON.parse(err));
                        }
                    }
                };

            makeRequest(options);

            return deferred.promise;
        };

        return {
            getJSON: getJSON,
            postJSON: postJSON
        };
    })();

    return httpRequest;
});