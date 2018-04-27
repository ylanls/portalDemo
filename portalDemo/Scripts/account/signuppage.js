SignUpPage = function () { };
SignUpPage.prototype = {
    constructor: SignUpPage,
    init: function () {
        this._initView();
        this._initEvent();
    },
    _initView: function () {

    },
    _initEvent: function () {
        $('#getcode').bind('click', function () {
            let telenum = $('input[name=telenum]').val();
            $.ajax({
                url: '/account/SendCode',
                type: 'get',
                success: function (result) {
                    alert('123')
                }
            });
        });
        $('.next-button').bind('click', function () {
            $('.error-span').text('');
            $.ajax({
                url: '/account/register',
                type: 'post',
                data: $('form').serialize(),
                success: function (result) {
                    switch (result) {
                        case "success":
                            window.location.href = '/account/login';
                            break;
                        case "userExist":
                            $('#emailError').text("用户已存在");
                            break;
                        case "passwordError":
                            $('#confirmPasswordError').text('两次密码不一致');
                            break;
                        case "emailInvalid":
                            $('#emailError').text("邮箱格式错误");
                            break;
                        case "failed":
                            $('#emailError').text("注册失败");
                            break;
                        case "nullEmail":
                            $('#emailError').text("不能为空");
                            break;
                        case "nullPassword":
                            $('#passwordError').text('不能为空');
                            break;
                    }
                }
            })

        })
        $('.login-button').bind('click', function () {
            $('.error-span').text('');
            $.ajax({
                url: '/account/login',
                type: 'post',
                data: $('form').serialize(),
                success: function (result) {
                    switch (result) {
                        case 'userNotExist':
                            $('#emailError').text("用户名或密码错误");
                            break;
                        case 'success':
                            window.location.href = '/home/index';
                            break;
                    }
                }
            })
        })
    },
}