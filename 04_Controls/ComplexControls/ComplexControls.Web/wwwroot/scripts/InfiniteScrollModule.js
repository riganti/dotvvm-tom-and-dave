export default context => new InfiniteScrollModule(context);

class InfiniteScrollModule {
    constructor(context) {
        this.context = context;

        this.commandName = "LoadMoreItems";
        this.sentinelSelector = "[data-infinite-scroll-sentinel]";

        this.observer = null;

        this.init();
    }

    init() {
        const sentinel = document.querySelector(this.sentinelSelector);
        if (!sentinel) {
            console.warn(`[InfiniteScrollModule] Sentinel not found: ${this.sentinelSelector}`);
            return;
        }

        this.disconnectObserver();
        this.observer = new IntersectionObserver(entries => {
            console.log("[InfiniteScrollModule] IntersectionObserver entries:", entries);
            if (entries[0]?.isIntersecting) {
                this.loadMoreIfNeeded();
            }
        });

        this.observer.observe(sentinel);
    }

    async loadMoreIfNeeded() {
        const command = this.context?.namedCommands?.[this.commandName];
        if (typeof command !== "function") {
            console.warn(`[InfiniteScrollModule] NamedCommand not found: ${this.commandName}`);
            return;
        }

        try {
            await command();
        } catch (error) {
            console.error("[InfiniteScrollModule] LoadMore command failed.", error);
        }
    }

    hello() {
        alert("hi!");
    }

    disconnectObserver() {
        if (this.observer) {
            this.observer.disconnect();
            this.observer = null;
        }
    }

    $dispose() {
        this.disconnectObserver();
    }
}