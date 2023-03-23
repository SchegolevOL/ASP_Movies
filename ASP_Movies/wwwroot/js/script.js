
//прослушка события error
$('img').on('erorr', function () {
    this.attr('src', '/images/on-image.png');
});