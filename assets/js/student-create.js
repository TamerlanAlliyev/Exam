const imageFileInput = document.getElementById('image-file');
const mainImage = document.querySelector('.main-image');
const photoOverlay = document.querySelector('.photo-overlay');

// Trigger file input on overlay click
photoOverlay.addEventListener('click', () => {
    imageFileInput.click();
});

// Update main image on file selection
imageFileInput.addEventListener('change', (event) => {
    const file = event.target.files[0];

    if (file && file.type.startsWith('image/')) {
        const reader = new FileReader();

        reader.onload = (e) => {
            mainImage.src = e.target.result;
        };

        reader.readAsDataURL(file);
    } else {
        alert('Please select a valid image file.');
        imageFileInput.value = '';
    }
});