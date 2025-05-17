const images = [
    "https://i.pinimg.com/736x/cb/f6/24/cbf6248c7fde06e7af2517efeedbf9a5.jpg",
    "https://i.pinimg.com/736x/6b/f5/ed/6bf5edc18cffc36318aca2eada9f771e.jpg",
    "https://i.pinimg.com/736x/59/b2/d7/59b2d724cfc4f0ca01898b4fc3b9a1c8.jpg"
];

let currentIndex = 0;
const currentImg = document.getElementById("sliderImageCurrent");
const nextImg = document.getElementById("sliderImageNext");

function slideToImage(index, direction = "right") {
    nextImg.className = "slide-image"; // Reset class
    currentImg.classList.remove("fade-out");

    // 1. Ảnh mới vào từ trái hoặc phải
    if (direction === "right") {
        nextImg.classList.add("hidden-left");
    } else {
        nextImg.classList.add("hidden-right");
    }

    // 2. Đổi ảnh tiếp theo
    nextImg.src = images[index];

    // 3. Kích hoạt animation
    requestAnimationFrame(() => {
        nextImg.classList.remove("hidden-left", "hidden-right");
        nextImg.classList.add("active");
        currentImg.classList.add("fade-out");
    });

    // 4. Sau khi xong animation, cập nhật lại vị trí
    setTimeout(() => {
        currentImg.src = nextImg.src;
        currentImg.classList.remove("fade-out");
        nextImg.classList.remove("active");
    }, 900); // khớp với thời gian transition CSS
}

function nextImage() {
    const nextIndex = (currentIndex + 1) % images.length;
    slideToImage(nextIndex, "right");
    currentIndex = nextIndex;
}

function prevImage() {
    const prevIndex = (currentIndex - 1 + images.length) % images.length;
    slideToImage(prevIndex, "left");
    currentIndex = prevIndex;
}

// Tự động chạy chuyển ảnh mỗi 5 giây từ phải sang trái
setInterval(() => {
    const nextIndex = (currentIndex + 1) % images.length;
    slideToImage(nextIndex, "left");
    currentIndex = nextIndex;
}, 5000);
