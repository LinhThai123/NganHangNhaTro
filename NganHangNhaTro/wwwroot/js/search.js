function searchProduct() {
    // Lấy dữ liệu từ thẻ input
    var searchValue = document.getElementById("searchInput").value;

    console.log(searchValue);
    // Hiển thị kết quả tìm kiếm trong phần tử div có id "result"

}

function searchProduct() {
    // Lấy dữ liệu từ thuộc tính data-id của thẻ input
    var searchValue = document.querySelector('[data-id="productInput"]').value;

    // Hiển thị kết quả tìm kiếm trong phần tử div có id "result"
    document.getElementById("result").innerText = "Bạn đã nhập: " + searchValue;

}

function searchProduct(searchTerm) {
    // Tạo đối tượng XMLHttpRequest
    var searchValue = document.querySelector('[data-id="productInput"]').value;
    var xhr = new XMLHttpRequest();

    // Thiết lập callback để xử lý khi nhận được dữ liệu từ server
    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 200) {
                var productList = JSON.parse(xhr.responseText);
                isRefreshing = true;
                renderData(productList);
            } else {
                console.log("Có lỗi xảy ra trong quá trình tải dữ liệu.");
            }
        }
    };

    // Tạo request và gửi lên server
    xhr.open("GET", "/Customer/Category/SearchProduct?searchTerm=" + searchValue, true);
    xhr.send();
}
//function renderData(data) {
//    // Kiểm tra nếu biến data là một Promise
//    if (data instanceof Promise) {
//        // Trích xuất dữ liệu từ Promise bằng cách sử dụng .then
//        data.then(function (dataArray) {
//            let htmlContent = '';
//            dataArray.forEach(real => {
//                htmlContent += `
//                    <div class="rld-filter-item col-lg-3 col-sm-6">
//                        <div class="single-feature">
//                            <div class="thumb">
//                                <img src="${real.imageUrl ? real.imageUrl : 'https://placehold.co/500x600/png'}" style="width:100%;height:100%; object-fit:cover;" alt="img">
//                            </div>
//                            <div class="details">
//                            <p class="author text-primary"><i class="fab fa-canadian-maple-leaf"></i> ${real.realEstateTypeName}</p>
//                            <h6 class="title"><a><i class="fas fa-map-marker-alt"></i> ${real.address}</a></h6>
//                            <div class="d-flex">
//                                <div class="h6 price mr-auto">${real.price} VNĐ/tháng</div>
//                                <div class="font-weight-bold">
//                                    <img src="~/assets/img/icons/7.png" alt="img"> ${real.acreage} m<sub style="vertical-align:super">2</sub>
//                                </div>
//                            </div>

//                            <ul class="info-list">
//                                <li class="mr-auto">Đăng bởi: <span class="font-weight-bold"></span>${real.agentName}</li>
//                            </ul>
//                            <ul class="info-list">
//                                <li class="mr-auto">Thời gian: <span class="font-weight-bold">${real.postTime}</span></li>
//                            </ul>
//                            <ul class="info-list">
//                                <li class="mr-auto">Liên hệ: <span class="font-weight-bold">${real.contactNumber}</span></li>
//                            </ul>
//                            @*<ul class="info-list">
//                                <li class="mr-auto">View: <span class="font-weight-bold">@item.ViewCount</span></li>
//                            </ul>*@
//                            <ul class="contact-list">
//                                <li><a class="btn btn-yellow" asp-action="Details" asp-route-id="${real.id}">Chi tiết</a></li>
//                            </ul>
//                        </div>
//                        </div>
//                    </div>
//                `;
//            });

//            // Thêm nội dung HTML vào phần tử có id "resultContainer"
//            $('#resultContainer').html(htmlContent);
//        }).catch(function (error) {
//            // Xử lý lỗi nếu Promise bị từ chối (rejected)
//            console.error('Error rendering data:', error);
//            // Có thể hiển thị một thông báo lỗi hoặc xử lý lỗi khác tùy ý
//        });
//    } else if (Array.isArray(data)) {
//        // Trường hợp data là một mảng trực tiếp
//        let htmlContent = '';
//        data.forEach(real => {
//            htmlContent += `
//                <div class="rld-filter-item col-lg-3 col-sm-6">
//                    <div class="single-feature">
//                        <div class="thumb">
//                            <img src="${real.imageUrl ? real.imageUrl : 'https://placehold.co/500x600/png'}" style="width:100%;height:100%; object-fit:cover;" alt="img">
//                        </div>
//                        <div class="details">
//                            <p class="author text-primary"><i class="fab fa-canadian-maple-leaf"></i> ${real.realEstateTypeName}</p>
//                            <h6 class="title"><a><i class="fas fa-map-marker-alt"></i> ${real.address}</a></h6>
//                            <div class="d-flex">
//                                <div class="h6 price mr-auto">${real.price} VNĐ/tháng</div>
//                                <div class="font-weight-bold">
//                                    <img src="~/assets/img/icons/7.png" alt="img"> ${real.acreage} m<sub style="vertical-align:super">2</sub>
//                                </div>
//                            </div>

//                            <ul class="info-list">
//                                <li class="mr-auto">Đăng bởi: <span class="font-weight-bold"></span>${real.agentName}</li>
//                            </ul>
//                            <ul class="info-list">
//                                <li class="mr-auto">Thời gian: <span class="font-weight-bold">${real.postTime}</span></li>
//                            </ul>
//                            <ul class="info-list">
//                                <li class="mr-auto">Liên hệ: <span class="font-weight-bold">${real.contactNumber}</span></li>
//                            </ul>
//                            @*<ul class="info-list">
//                                <li class="mr-auto">View: <span class="font-weight-bold">@item.ViewCount</span></li>
//                            </ul>*@
//                            <ul class="contact-list">
//                                <li><a class="btn btn-yellow" asp-action="Details" asp-route-id="${real.id}">Chi tiết</a></li>
//                            </ul>
//                        </div>
//                    </div>
//                </div>
//            `;
//        });

//        // Thêm nội dung HTML vào phần tử có id "resultContainer"
//        $('#resultContainer').html(htmlContent);
//    } else {
//        // Xử lý trường hợp data không hợp lệ (không phải Promise hoặc mảng)
//        console.error('Invalid data format:', data);
//        // Có thể hiển thị một thông báo lỗi hoặc xử lý lỗi khác tùy ý
//    }
//}
function renderData(data) {
    let htmlContent = '';
    data.then(function (data) {
        dataArray.forEach(real => {
            htmlContent += `
                <div class="rld-filter-item col-lg-3 col-sm-6">
                    <div class="single-feature">
                        <div class="thumb">
                            <img src="${real.imageUrl ? real.imageUrl : 'https://placehold.co/500x600/png'}" style="width:100%;height:100%; object-fit:cover;" alt="img">
                        </div>
                        <div class="details">
                            <p class="author text-primary"><i class="fab fa-canadian-maple-leaf"></i> ${real.realEstateTypeName}</p>
                            <h6 class="title"><a><i class="fas fa-map-marker-alt"></i> ${real.address}</a></h6>
                            <div class="d-flex">
                                <div class="h6 price mr-auto">${real.price} VNĐ/tháng</div>
                                <div class="font-weight-bold">
                                    <img src="~/assets/img/icons/7.png" alt="img"> ${real.acreage} m<sub style="vertical-align:super">2</sub>
                                </div>
                            </div>

                            <ul class="info-list">
                                <li class="mr-auto">Đăng bởi: <span class="font-weight-bold"></span>${real.agentName}</li>
                            </ul>
                            <ul class="info-list">
                                <li class="mr-auto">Thời gian: <span class="font-weight-bold">${real.postTime}</span></li>
                            </ul>
                            <ul class="info-list">
                                <li class="mr-auto">Liên hệ: <span class="font-weight-bold">${real.contactNumber}</span></li>
                            </ul>
                            @*<ul class="info-list">
                                <li class="mr-auto">View: <span class="font-weight-bold">@item.ViewCount</span></li>
                            </ul>*@
                            <ul class="contact-list">
                                <li><a class="btn btn-yellow" asp-action="Details" asp-route-id="${real.id}">Chi tiết</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            `;
        });

        $('#resultContainer').html(htmlContent);
    });
}

