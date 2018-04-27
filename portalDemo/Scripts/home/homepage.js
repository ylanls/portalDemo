HomePage = function () {

};
HomePage.prototype = {
    constructor: HomePage,
    init: function () {
        this._initView();
        this._initEvent();
    },
    _initView: function () {
        let count = 0;
        setInterval(function () {
            count++;
            if (count == 7)
                count = 1;
            var imgUrl = '/Content/themes/images/' + count + '_C_500_280.jpg';
            $('#home-img').attr('src', imgUrl);
        }, 3000);

    },
    _initEvent: function () {
        $('.menu-container span').bind('click', function () {
            $('.menu-container span').removeClass('menu-selected');
            $(this).addClass('menu-selected');
            $('.menu-body-div').addClass('display-none');
            var currentId = $(this).attr('data-id');
            if (currentId === 'map-view') {
                var map = new AMap.Map('map-div', {
                    center: [122.941794, 40.096536],
                    zoom: 12
                });
                marker = new AMap.Marker({
                    position: [122.941794, 40.096536],
                    title: '天门山国家森林公园'
                });
                marker.setMap(map);
            }
            $('#' + currentId).removeClass('display-none');
        })
        $('#show-map').bind('click', function () {
            $('#show-map-but').click();
        })
        $('.but').bind('click', function () {
            var currentType = $(this).attr('data-tickettype');
            window.location.href = '/subscription/index?type=' + currentType;
        })
    }
}