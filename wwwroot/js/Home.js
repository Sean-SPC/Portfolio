var randomNum = 0;

var sonicLoaders = [
    "sonic-spindash",
    "sonic-jog",
    "sonic-run"
]

onload();

function onload() {
    var index = Math.floor(Math.random() * sonicLoaders.length);
    document.getElementById("spindash-loader").src = `src/images/${sonicLoaders[1]}.gif`;

    setTimeout(() => {
        document.getElementById("spindash-loader-div").style.display = "none"; 
        document.getElementById("non-loading-container").style.display = "inline-block";
    }, 2000);
}