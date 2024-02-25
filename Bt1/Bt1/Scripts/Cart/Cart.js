//Nếu nó báo lỗi ko tìm thấy thèn hàm nào trog đây thì nhớ save file lại rùi chạy

AddItemToCart = function (e) {
    //Lấy giỏ ra để bắt đầu mua hàng
    var store = GetCookie('MyShoppingCart');

    //Đi lấy hàng
    //mấy thèn id này dc đặt tên và sử dụng bên ListPartialView như data-productid
    //khc tên thì dù hiển thị thông báo thành công nhưng vẫn ko lấy dc id
    var item = {
        ProductID: $(e).data('productid'),
        ProductName: $(e).data('productname'),
        Quality: 1,
        Price: $(e).data('price'),
        Image: $(e).data('image')
    };

    //Bỏ vào trong giỏ
    AddAndUpdateShoppingCart(store, item);

    alert("Thêm vào giỏ thành công");
}

RemoveItemFromCart = function (e) {

    var result = confirm("Muốn xóa ko");
    if (result) { 

    //lấy giỏ hàng
    var store = GetCookie('MyShoppingCart');
    //Đưa vào cái item cần xóa
    var item = {
        ProductID: $(e).data('productid'),
        ProductName: $(e).data('productname'),
        Quality: 1,
        Price: $(e).data('price'),
        Image: $(e).data('image')
    };

    //thực hiện xóa
    RemoveItemFromShoppingCart(store, item);

    window.location.href = "/ShoppingCart/Index"
    } 
}

UpdateCartItem = function (e) {
    
    //lấy giá trị của ô input
    var quantity = $("#txtQuantity").val();

    //lấy giỏ
    var store = GetCookie('MyShoppingCart');

    //Đưa vào cái item cần Update
    var item = {
        ProductID: $(e).data('productid'),
        ProductName: $(e).data('productname'),
        Quality: 1,
        Price: $(e).data('price'),
        Image: $(e).data('image')
    };

    //kiểm tra xem trog giỏ có sản phẩm đó ko
    var index = store.findIndex(function (d) {
        return d.ProductID == item.ProductID;
    });

    //nếu k có thì dừng luôn
    if (store.length == 0 || index == -1) {
        return;
    }
    //ngược lại thì set lại số lg của sản phẩm trog giỏ
    store[index].Quality = quantity;
    SetCookie('MyShoppingCart', store);

    window.location.href = "/ShoppingCart/Index";

}


AddAndUpdateShoppingCart = function (store, item, quantity) {
    //Tìm id có chx
    var index = store.findIndex(function (d) {
        return d.ProductID == item.ProductID;
    });
    //chx có thì push item vào 
    if (store.length == 0 || index == -1) {
        store.push(item);
        SetCookie('MyShoppingCart', store);
        return store;
    }
    //nếu số lg ko null or undefined thì 
    if (quantity != null && quantity != "undefined") {
        store[index].Quality = quantity;
    } else {
        store[index].Quality = parseInt(store[index].Quality) + 1;
    }
    //đưa vào giỏ rồi thì set
    SetCookie('MyShoppingCart', store);
    return store;
}

RemoveItemFromShoppingCart = function (store, item) {
    if (store.length > 0) {
        var index = store.findIndex(function (d) {
            return d.ProductID == item.ProductID;
        });

        store.splice(index, 1);
        SetCookie('MyShoppingCart', store);
        return store;
    }
}