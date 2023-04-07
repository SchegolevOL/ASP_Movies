$('[data-open-modal]').click(async function (event) {


    event.preventDefault();
    $('.modal-body').html(" ");
    $('#movieModal').modal('show');
    let url = $(this).attr('href');
    let response = await fetch(url);
    let result = await response.text();
   

    $('.modal-body').html(result);


})

let page;
let url;
let totalPages;
let isScrol = true;
let isEnd = false;
function initPagination(p, u, t) {
    page = p;
	totalPages = t;
	url = u;
}

$('#buttonNext').click(async function () {
	page++;
	let response = await fetch(`${url}?page=${page}`);
    let result = await response.text();
	
	$('#movieResult').append(result)

	if (totalPages == page) $(this).remove();

})	

$(window).scroll(async function () {
    if (!isEnd) {
        if ($(this).scrollTop() + $(this).height() > $(document).height() - 250 && isScrol) {
     isScrol=false
        page++;
        let response = await fetch(`${url}?page=${page}`);
        let result = await response.text();

        $('#movieResult').append(result)

            if (totalPages == page) isEnd = true;
            isScrol = true;
    }
    }
   
})