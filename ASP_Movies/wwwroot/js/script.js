//$('[data-open-modal]').click(async function (event) {


//	event.preventDefault();
//	$('.modal-body').html(" ");
//	$('#movieModal').modal('show');
//	let url = $(this).attr('href');
//	let response = await fetch(url);
//	let result = await response.text();


//	$('.modal-body').html(result);


//})

//let page;
//let url;
//let totalPages;
////function a() {
////    console.log("hello");
////}

//function initPagination(p, u, t) {
//	page = p;
//	totalPages = t;
//	url = u;
//}

//$('#buttonNext').click(async function () {
//	page++;
//	console.log(page);
//	console.log(url);
//	console.log(totalPages);

//	console.log(page);
//	url = url + `?page=${page}`;
//	console.log(url);
//	let response = await fetch(url);

//	let result = await response.text();
//	console.log("result = ");
//	console.log(result);

//	$('#movieResult').append(result)

//	if (totalPages == page) $(this).remove();
//}
//})	

//прослушка события error
//$("img").on("erorr", function () {
//    this.attr("src", "/images/no-image.png");
//});



//$('[data-open-modal]').click(async function () {


//    event.preventDefault();
//    $('.modal-body').html(" ");
//    $('#movieModal').modal('show');
//    let url = $(this).attr('href');
//    let response = await fetch(url);
//    let result = await response.text();
//    console.log(result)

//    $('.modal-body').html(result);


//})