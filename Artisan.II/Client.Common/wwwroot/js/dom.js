export function replayAnimation(element, animationClasses) {
    element.classList.remove(animationClasses);
    setTimeout(() => element.classList.add(animationClasses), 1);
}