document.addEventListener('DOMContentLoaded', function() {
    const togglePassword = document.getElementById('togglePassword');
    const toggleVerifyPassword = document.getElementById('toggleVerifyPassword');
    const password = document.getElementById('password');
    const verifyPassword = document.getElementById('verifyPassword');

    function togglePasswordVisibility(inputField, toggleIcon) {
        if (inputField.type === 'password') {
            inputField.type = 'text';
            toggleIcon.classList.remove('bxs-lock-alt');
            toggleIcon.classList.add('bx-lock-open-alt');
        } else {
            inputField.type = 'password';
            toggleIcon.classList.remove('bx-lock-open-alt');
            toggleIcon.classList.add('bxs-lock-alt');
        }
    }

    togglePassword.addEventListener('click', function() {
        togglePasswordVisibility(password, this);
    });

    toggleVerifyPassword.addEventListener('click', function() {
        togglePasswordVisibility(verifyPassword, this);
    });
});