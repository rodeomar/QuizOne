const cards = document.querySelectorAll('.customCard');

const observer = new IntersectionObserver(entries => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.style.opacity = 1;
            entry.target.style.transform = 'translateX(0)';
        }
    });
});

cards.forEach(card => {
    observer.observe(card);
});