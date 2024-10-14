document.addEventListener('DOMContentLoaded', () => {
    const loginForm = document.getElementById('loginForm');
    const message = document.getElementById('message');
    const togglePassword = document.getElementById('togglePassword');
    const passwordInput = document.getElementById('password');
    const confirmPasswordInput = document.getElementById('confirmPassword');

    togglePassword.addEventListener('click', () => {
        const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
        passwordInput.setAttribute('type', type);
        togglePassword.textContent = type === 'password' ? '👁️' : '🔒';
    });

    loginForm.addEventListener('submit', (e) => {
        e.preventDefault();

        const username = document.getElementById('username').value;
        const password = passwordInput.value;
        const confirmPassword = confirmPasswordInput.value;

        if (password !== confirmPassword) {
            message.textContent = 'Las contraseñas no coinciden. Por favor, inténtalo de nuevo.';
            message.className = 'message error';
            return;
        }

        // Aquí normalmente harías una llamada a tu API para verificar las credenciales
        // Por ahora, simularemos una verificación simple
        if (username === 'usuario' && password === 'contraseña') {
            message.textContent = '¡Inicio de sesión exitoso!';
            message.className = 'message success';
            // Aquí podrías redirigir al usuario a su página de inicio
        } else {
            message.textContent = 'Usuario o contraseña incorrectos. Por favor, inténtalo de nuevo.';
            message.className = 'message error';
        }
    });
});
