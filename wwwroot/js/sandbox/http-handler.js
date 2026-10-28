
document.addEventListener("DOMContentLoaded", () => {
    const server = document.querySelector("#server");
    const packets = document.querySelectorAll(".packet");

    let isAnimating = false;
    let resetTimer;

    server.addEventListener("mouseenter", () => {
        if (isAnimating) return;

        isAnimating = true;
        server.classList.add("animating");

        // Find when the last packet finishes.
        const lastPacket = packets[packets.length - 1];
        const duration = parseFloat(
            getComputedStyle(lastPacket).animationDuration
        ) * 1000;
        const delay = parseFloat(
            getComputedStyle(lastPacket).animationDelay
        ) * 1000;

        clearTimeout(resetTimer);

        resetTimer = setTimeout(() => {
            server.classList.remove("animating");

            // Allow the CSS animation to reset before the next hover.
            packets.forEach(packet => {
                packet.style.animation = "none";
            });

            void server.offsetWidth;

            packets.forEach(packet => {
                packet.style.animation = "";
            });

            isAnimating = false;
        }, duration + delay + 3000);
    });
});