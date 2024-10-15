function togglePasswordVisibility(inputId, iconId) {
    const input = document.getElementById(inputId);
    const icon = document.getElementById(iconId);
    
    if (input.type === "password") {
        input.type = "text";
        icon.classList.remove('bxs-lock-alt');
        icon.classList.add('bxs-lock-open-alt');
    } else {
        input.type = "password";
        icon.classList.remove('bxs-lock-open-alt');
        icon.classList.add('bxs-lock-alt');
    }
}

document.addEventListener('DOMContentLoaded', function() {
    document.getElementById('togglePassword').addEventListener('click', function() {
        togglePasswordVisibility('password', 'togglePassword');
    });

    document.getElementById('toggleVerifyPassword').addEventListener('click', function() {
        togglePasswordVisibility('verifyPassword', 'toggleVerifyPassword');
    });
});