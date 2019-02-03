var counter = 0;

// Checks to see if this is the final question
var CheckLast = function (questionCount) {

    counter++;

    if (counter === questionCount) {
        window.location.replace('/Assessment/Completed');
    }
    
};