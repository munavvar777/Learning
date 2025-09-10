document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('form');
    const inputs = form.querySelectorAll('input');
    const submitBtn = form.querySelector('button[type="submit"]');

    // Validate each input
    inputs.forEach(input => {
        input.addEventListener('blur', () => validateField(input));
        input.addEventListener('input', () => {
            if (input.classList.contains('is-invalid')) {
                validateField(input);
            }
        });
    });

    function validateField(field) {
        const errorSpan = field.closest('.mb-3').querySelector('span');
        let isValid = true;
        let errorMessage = '';

        if (field.hasAttribute('required') && !field.value.trim()) {
            isValid = false;
            errorMessage = 'This field is required';
        } else if (field.type === 'email' && field.value && !isValidEmail(field.value)) {
            isValid = false;
            errorMessage = 'Please enter a valid email address';
        } else if (field.name === 'Password' && field.value.length < 6) {
            isValid = false;
            errorMessage = 'Password must be at least 6 characters';
        } else if (field.name === 'ConfirmPassword') {
            const passwordField = form.querySelector('input[name="Password"]');
            if (field.value !== passwordField.value) {
                isValid = false;
                errorMessage = 'Passwords do not match';
            }
        }

        if (isValid) {
            field.classList.remove('is-invalid');
            field.classList.add('is-valid');
            errorSpan.textContent = '';
        } else {
            field.classList.remove('is-valid');
            field.classList.add('is-invalid');
            errorSpan.textContent = errorMessage;
        }

        return isValid;
    }

    function isValidEmail(email) {
        return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
    }

    // Form submission
    form.addEventListener('submit', function (e) {
        let isFormValid = true;

        inputs.forEach(input => {
            if (!validateField(input)) {
                isFormValid = false;
            }
        });

        if (!isFormValid) {
            e.preventDefault();
            form.classList.add('shake');
            setTimeout(() => form.classList.remove('shake'), 600);
        } else {
            submitBtn.innerHTML = '<span>Creating Account...</span>';
            submitBtn.disabled = true;
        }
    });
});

// Add shake animation
const style = document.createElement('style');
style.textContent = `
    @keyframes shake {
        0%, 20%, 40%, 60%, 80% { transform: translateX(0); }
        10%, 30%, 50%, 70%, 90% { transform: translateX(-6px); }
    }
    .shake { animation: shake 0.6s ease-in-out; }
`;
document.head.appendChild(style);
