/*const arr_Image = [
    "~/Content/img/Slide1.jpg",
    "~/Content/img/Slide4.jpg",
    "~/Content/img/Slide2.jpg",
    "~/Content/img/Slide4.jpg",
    "~/Content/img/Slide2.jpg",
    "~/Content/img/Slide4.jpg"
];

index = 0;

function prev() {
    index--;
    if (index <= 0) index = arr_Image.length - 1;
    document.getElementById("image").src = arr_Image[index];
}

function next() {
    index++;
    if (index == arr_Image.length) index = 0;
    document.getElementById("image").src = arr_Image[index];
}

window.setInterval(next, 5000);*/

//them gio hang

const btn = document.querySelectorAll(".cart-btn");
btn.forEach(function (a, index) {
    //console.log(a, index);
    a.addEventListener("click", function (event) {
        {
            var btnItem = event.target;
            var product = btnItem.parentElement.parentElement.parentElement;
            var productImg = product.querySelector("img").src;
            var productName = product.querySelector("h3").innerText;
            var productPrice = product.querySelector('.price').textContent.trim().split(' ')[0];
            addcart(productPrice, productImg, productName);
            console.log(productImg)

        }
    })
})

// function addcart(productPrice, productImg, productName) {
//     var addstr = document.createElement("tr");
//     var trcontent = '<tr><td style="display: flex; align-items: center;"><img src="' + productImg + '" alt="" style="width: 70px;"> ' + productName + '</td><td><p><span>' + productPrice + '</span><sup>đ</sup></p></td><td><input style="width: 30px; border:  1px solid black;border-radius: 3px ; color: black;" type="number" value="1" min="1"></td><td style="cursor: pointer;">Xoá</td></tr>';

//     addstr.innerHTML = trcontent;
//     var cartTable = document.querySelector("tbody");
//     cartTable.append(addstr);
//     carttotal();
// }


function addcart(productPrice, productImg, productName) {
    // Xử lý thêm <Tr> cho <Tbody>
    var addtr = document.createElement("tr");
    var cartItem = document.querySelectorAll("tbody tr");
    for (var i = 0; i < cartItem.length; i++) {
        var itemName = cartItem[i].querySelector(".item_name").innerHTML;
        if (itemName == productName) {
            alert("Sản phẩm 「" + productName + "」 bạn chọn đã có trong giỏ hàng !");
            return;
        }
    }
    var trContent =
        "<tr>" +
        '<td style="display: flex; align-items: center;"><img style="width:100px;" src="' +
        productImg +
        '" alt="Iphone thumb"><span class="item_name">' +
        productName +
        "</span>" +
        "</td>" +
        "<td>" +
        "<p>" +
        '<span class="item_price">' +
        productPrice +
        "</span>" +
        "<sup>đ</sup>" +
        "</p>" +
        "</td>" +
        "<td>" +
        '<input class="item_quantity" style="width:30px; border:1px solid black; border-radius: 3px ; color: black" type="number" value="1" min="1">' +
        "</td>" +
        '<td style="cursor: pointer"><span class="item_delete">Xóa</span></td>' +
        "</tr>";
    addtr.innerHTML = trContent;
    var cartTable = document.querySelector("tbody");
    cartTable.append(addtr);

    // move đến thẻ <tr> mới tạo ra

    var lastTr = cartTable.lastElementChild;

    // Xử lý event cho button 'xóa' 
    var itemDelete = lastTr.querySelector(".item_delete");
    itemDelete.addEventListener("click", function (event) {
        var target = event.target;
        var targetTr = target.parentElement.parentElement;
        targetTr.remove();
        // Reset lại giá tổng
        carttotal();
    });

    // Xử lý event update số lượng sản phẩm
    var quantityChange = lastTr.querySelector(".item_quantity");
    quantityChange.addEventListener("change", function (event) {
        // Reset lại giá tổng
        carttotal();
    });

    // Tính tổng giá tiền
    carttotal();
}


//total price
function carttotal() {
    var cartItem = document.querySelectorAll("tbody tr");
    //console.log(cartItem)
    var totalC = 0;
    for (var i = 0; i < cartItem.length; i++) {
        var inputValue = cartItem[i].querySelector("input").value;

        var productPrice = cartItem[i].querySelector(".item_price").innerHTML;

        totalA = inputValue * productPrice

        totalC += totalA
    }

    var cartTotalA = document.querySelector(".price-total span")
    cartTotalA.innerHTML = totalC
    console.log(cartTotalA)
}

const cartbtn = document.querySelector(".fa-times")
const cartshow = document.querySelector(".bx-cart")

cartshow.addEventListener("click", function () {
    document.querySelector(".cart").style.right = "0";
})

cartbtn.addEventListener("click", function () {
    document.querySelector(".cart").style.right = "-100%";
})

