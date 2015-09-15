$(function () {
    var token = {};

    $('#btnLogin').click(function () {
        $.ajax('/token', {
            type: 'post',
            data: {
                username: 'maurice',
                password: 'secret',
                grant_type: 'password'
            }
        }).then(
            function (data) {
                token.access_token = data.access_token;
                token.token_type = data.token_type;

                $('#result').text(JSON.stringify(data));
            },
            function (err) {
                $('#result').text(JSON.stringify(err));
            }
        );
    });

    $('#btnUser').click(function () {
        $.ajax('/api/user', {
            headers: {
                Authorization: token.token_type + ' ' + token.access_token
            }
        }).then(
            function (data) {
                $('#result').text(data);
            },
            function (err) {
                $('#result').text(JSON.stringify(err));
            }
        );
    });
});
