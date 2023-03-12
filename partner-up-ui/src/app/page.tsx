import React from 'react';

function PartnerUpLogo() {
    return (
        <a
            href="#"
            className="font-bold px-3 py-2 border border-green-400 hover:bg-gray-50 dark:hover:bg-neutral-800"
        >
            <span className="dark:text-white">partner</span>
            <span className="text-green-400">UP</span>
        </a>
    );
}

export default function Home() {
    return (
        <main className="min-h-screen bg-base-200 dark:bg-base-100">
            <section className="w-full min-h-screen lg:max-w-2xl mx-auto bg-base-100 dark:bg-base-200 lg:border-x lg:border-x-neutral-900 dark:border-x-neutral-800">
                <div className="w-full flex sticky top-0 h-14 backdrop-blur">
                    <div className="navbar border-b border-b-neutral-900 dark:border-b-neutral-800">
                        <div className="navbar-start"></div>
                        <div className="navbar-center">
                            <PartnerUpLogo></PartnerUpLogo>
                        </div>
                        <div className="navbar-end"></div>
                    </div>
                </div>
                <div className="w-full flex sticky top-[100vh] h-14 border-t border-t-neutral-900 dark:border-t-neutral-800">
                </div>
            </section>
        </main>
    );
}
