
const letters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';

document.addEventListener('DOMContentLoaded', () => {
    const letterContainers = document.querySelectorAll('.letter-container');

    letterContainers.forEach(container => {
        const middle = container.querySelector('.middle');

        let syncTimeout;

        middle.addEventListener('animationiteration', () => {
            const upper = container.querySelector('.upper');
            const lower = container.querySelector('.lower');

            const upperLetter = upper.querySelector('.letter');
            const lowerLetter = lower.querySelector('.letter');

            // Generate random letters
            upperLetter.textContent = letters[Math.floor(Math.random() * letters.length)];
            lowerLetter.textContent = letters[Math.floor(Math.random() * letters.length)];

            // Randomise this container's direction
            const direction = Math.random() < 0.5 ? -1 : 1;

            container.style.setProperty('--r', direction);

            // Set active element for this container
            upper.classList.toggle('active', direction === 1);
            lower.classList.toggle('active', direction === -1);

            // Prevent overlapping pending synchronisations
            clearTimeout(syncTimeout);

            syncTimeout = setTimeout(() => {
                const middleLetter = middle.querySelector('.letter');

                middleLetter.textContent =
                    direction === 1
                        ? upperLetter.textContent
                        : lowerLetter.textContent;

            }, 1000);
        });
    });
});