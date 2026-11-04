let themes = {};
let currentTheme = "sonic";

async function loadThemes() {
    try {
        const response = await fetch("/api/themes");

        if (!response.ok) {
            throw new Error("Failed to load themes");
        }

        themes = await response.json();

        // Retrieve saved theme
        currentTheme = localStorage.getItem("currentTheme") || "sonic";

        // Validate saved theme
        if (!themes[currentTheme]) {
            currentTheme = "sonic";
        }

        applyTheme(currentTheme);

    } catch (error) {
        console.error("Theme loading error:", error);
    }
}

function changeTheme(themeName) {
    if (!themes[themeName]) return;

    currentTheme = themeName;

    localStorage.setItem("currentTheme", currentTheme);

    applyTheme(currentTheme);
}

function applyTheme(themeName) {
    const theme = themes[themeName];

    if (!theme || !theme["home-icon"]) {
        console.error(`Invalid theme configuration: ${themeName}`);
        return;
    }

    document.getElementById("homeIcon").src = theme["home-icon"];
    document.getElementById("themes").value = themeName;
}

document.addEventListener("DOMContentLoaded", loadThemes);