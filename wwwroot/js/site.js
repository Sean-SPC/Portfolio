function changeTheme(themeName) {
    document.cookie = `CurrentTheme=${encodeURIComponent(themeName)}; path=/; max-age=31536000; samesite=lax`;

    // Update the page's theme assets here as well.
}