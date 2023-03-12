import React from 'react';

function PartnerUpLogo() {
    return (
        <a href="#" className="font-bold p-3 border border-green-400 hover:bg-gray-50 dark:hover:bg-neutral-800">
            <span className="dark:text-white">partner</span>
            <span className="text-green-400">UP</span>
        </a>
    );
}

export default function Home() {
    return (
        <main className="bg-white dark:bg-neutral-900 w-full h-screen flex justify-center items-center">
            <PartnerUpLogo></PartnerUpLogo>
        </main>
    );
}
