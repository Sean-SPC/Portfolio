const letters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
const duration = parseFloat(getComputedStyle(document.documentElement).getPropertyValue('--duration')) * 1000;
const _84 = duration * 0.84;

document.addEventListener('DOMContentLoaded', () => {
    const letterContainers = document.querySelectorAll('.letter-container');

    letterContainers.forEach(container => {
        const target = container.dataset.target.toUpperCase();

        // Containers
        const middle = container.querySelector('.middle');
        const upper = container.querySelector('.upper');
        const lower = container.querySelector('.lower');

        // Letters
        const middleLetter = middle.querySelector('.letter');
        const upperLetter = upper.querySelector('.letter');
        const lowerLetter = lower.querySelector('.letter');

        if (container.classList.contains('inactive')) {
            middleLetter.textContent = target;
            container.classList.add('completed'); return;
        }

        let count = parseInt(container.dataset.count);
        const cap = parseInt(container.dataset.cap);

        // Generate random letters
        do { upperLetter.textContent = letters[Math.floor(Math.random() * letters.length)]; } while (upperLetter.textContent == target)
        do { lowerLetter.textContent = letters[Math.floor(Math.random() * letters.length)]; } while (lowerLetter.textContent == target)

        // Randomise this container's direction
        const direction = Math.random() < 0.5 ? -1 : 1;
        container.style.setProperty('--r', direction);

        // Set active element
        upper.classList.toggle('active', direction === 1);
        lower.classList.toggle('active', direction === -1);

        // At 84%
        setTimeout(() => {
            middleLetter.textContent = (direction === 1 ? upperLetter : lowerLetter).textContent;
        }, _84);

        // At 100%
        setTimeout(() => {
            // Check whether this spot has reached its target
            if (middleLetter.textContent === target) { container.classList.add('completed'); return; }
        }, duration);

        count++;

        middle.addEventListener('animationiteration', () => {
            // Generate random letters
            do { upperLetter.textContent = letters[Math.floor(Math.random() * letters.length)]; } while (upperLetter.textContent == target)
            do { lowerLetter.textContent = letters[Math.floor(Math.random() * letters.length)]; } while (lowerLetter.textContent == target)

            // Randomise this container's direction
            const direction = Math.random() < 0.5 ? -1 : 1;
            container.style.setProperty('--r', direction);

            // Set active element
            upper.classList.toggle('active', direction === 1);
            lower.classList.toggle('active', direction === -1);

            // Final iteration
            if (count >= cap - 1) {
                (direction === 1 ? upperLetter : lowerLetter).textContent = target;
            }

            // At 84%
            setTimeout(() => {
                middleLetter.textContent = (direction === 1 ? upperLetter : lowerLetter).textContent;
            }, _84);

            // At 100%
            setTimeout(() => {
                // Check whether this spot has reached its target
                if (middleLetter.textContent === target) { container.classList.add('completed'); return; }
            }, duration);

            count++;
        });
    });
});

function firstIteration() {

}

function Iteration() {

}

function FinalLoop() {

}