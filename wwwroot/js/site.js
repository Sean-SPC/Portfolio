// let themes = {};
// let currentTheme = "infamous-good";

// async function loadThemes() {
//     try {
//         const response = await fetch("/api/themes");

//         if (!response.ok) {
//             throw new Error("Failed to load themes");
//         }

//         themes = await response.json();

//         // Retrieve saved theme
//         currentTheme = localStorage.getItem("currentTheme") || "infamous-good";

//         // Validate saved theme
//         if (!themes[currentTheme]) {
//             currentTheme = "infamous-good";
//         }

//         applyTheme(currentTheme);

//     } catch (error) {
//         console.error("Theme loading error:", error);
//     }
// }

// function changeTheme(themeName) {
//     if (!themes[themeName]) return;

//     currentTheme = themeName;

//     localStorage.setItem("currentTheme", currentTheme);

//     applyTheme(currentTheme);
// }

// function applyTheme(themeName) {
//     const theme = themes[themeName];

//     if (!theme || !theme["home-icon"]) {
//         console.error(`Invalid theme configuration: ${themeName}`);
//         return;
//     }

//     const cacheBuster = `?v=${Date.now()}`;

//     document.getElementById("homeIcon").src =
//         theme["home-icon"] + cacheBuster;

//     document.getElementById("background-static").src =
//         theme["background-static"] + cacheBuster;

//     document.getElementById("themes").value = themeName;
// }

// document.addEventListener("DOMContentLoaded", loadThemes);

// const myModal = document.getElementById('myModal')
// const myInput = document.getElementById('myInput')

// myModal.addEventListener('shown.bs.modal', () => {
//     myInput.focus()
// })