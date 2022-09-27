// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//$(() => {
//    let connection = new signalR.HubConinectionBuilder().withUrl("/").build();
//    connection.on("refreshEmployees", function () {
//        loadProducts();
//    });
//    function loadProducts() {
//        var tr = '';
//        $.ajax({
//            url: 'home/products',
//            method: 'GET',
//            success: (result) => {
//                $.each(result, (key, value) => {
//                    tr = tr + '<tr><td> ${ value.id }</td><td> ${ value.productName}</td><td> ${ value.description}</td>                            <td> ${value.unitsInStock}</td><td> ${value.price}</td></tr> ';
//                })
//                $('#products').html(tr)
//            },
//            error: (result) => {
//                console.log(result);
//            }
//        })
//    }
//});
$(() => {
    let connection = new signalR.HubConnectionBuilder().withUrl("/SignalServer").build();
    connection.start();

    connection.on("refreshEmployees", function () {
        loadProducts();
    });

    loadProducts();
    function loadProducts() {
        var tr = '';
        $.ajax({
            url: '/home/products',
            method: 'GET',
            success: (result) => {
                $.each(result, (key, value) => {
                    tr = tr + `<tr>
                                <td> ${value.id} </td>
                                <td> ${value.productName} </td>
                                <td> ${value.description} </td>
                                <td> ${value.unitsInStock} </td>
                                <td> ${value.price} </td>
                                </tr>`;
                })
                $('#products').html(tr);
            },
            error: (result) => {
                console.log(result);
            }
        })
    }
});