$(document).ready(function () {
    doInit();
});

var setSeconds = function () {
    var d = new Date();
    $('#progress-bar').val(60 - d.getSeconds());
};

var buildNumbers = function (nums) {

            $('#progress-bar').hide();
            $('#pingrid').empty();
                        
            var ms = 6;

            for (j = 1; j <= parseInt(ms) ; ++j) {
                var div = $('<div class="row">');
                for (k = 1; k <= parseInt(ms) ; ++k) { div.append('<span>'); }
                $('#pingrid').append(div);
            }

            $('#progress-bar').show();

            $('.pingrid span').css({
                transform: 'rotateY(30deg)',
                '-webkit-transform': 'rotateY(30deg)'
            });

            var spans = document.getElementsByTagName("span");

            for (i = 0; i < spans.length; ++i) {
                num = nums[Math.floor(Math.random() * nums.length)];
                spans[i].innerHTML = num;
            }

            setTimeout(function () {
                $('.pingrid span').css({
                    transform: 'rotateY(0)',
                    '-webkit-transform': 'rotateY(0)'
                });
            }, 1500);
            
            setSeconds();
        };

var doProgress = function () {
    if (parseInt($('#progress-bar').val()) > 0) {
        $('#progress-bar').val(function () {
            return parseInt($('#progress-bar').val()) - 1
        });
    } else {
        NativeFunc('getPinGridValues', 'test', function (returnData) {
            buildNumbers(returnData);
        });
    }
};

var doInit = function () {
    alert('hello');
    NativeFunc('getPinGridValues', 'test', function (returnData) {
        alert(returnData);
        buildNumbers(returnData);
    });
};

$(window.setInterval(function () {
    doProgress();
}, 1000));
