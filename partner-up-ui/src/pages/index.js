import React from 'react';
import { IoAlertCircleOutline } from 'react-icons/io5';

function PartnerUpLogo() {
    return (
        <a
            href="#"
            className="btn btn-ghost font-bold px-3 py-2"
        >
            <span className="dark:text-white lowercase">partner</span>
            <span className="text-green-400 uppercase">UP</span>
        </a>
    );
}

export default function Home() {
    return (
        <main className="min-h-screen bg-base-200 dark:bg-base-100">
            <section className="w-full min-h-screen lg:max-w-2xl mx-auto bg-base-100 dark:bg-base-200 lg:border-x dark:border-x-neutral-800">
                <div className="w-full flex sticky top-0 bg-base-100 dark:bg-base-200 bg-opacity-90 dark:bg-opacity-75 backdrop-blur">
                    <div className="navbar border-b dark:border-b-neutral-800">
                        <div className="navbar-start"></div>
                        <div className="navbar-center">
                            <PartnerUpLogo></PartnerUpLogo>
                        </div>
                        <div className="navbar-end"></div>
                    </div>
                </div>
                <section>
                    <div className="container flex flex-col items-center px-4 py-12 mx-auto text-center">
                        <h2 className="max-w-2xl mx-auto text-2xl font-semibold tracking-tight text-gray-800 xl:text-3xl dark:text-white">
                            Bring your Work to
                            the <span className="text-green-400">next level.</span>
                        </h2>
                        <p className="max-w-4xl mt-6 text-center text-gray-500 dark:text-gray-300">
                            Lorem, ipsum dolor sit amet consectetur
                            adipisicing elit. Cum quidem officiis reprehenderit, aperiam veritatis
                            non, quod veniam fuga possimus hic
                            explicabo laboriosam nam. A tempore totam ipsa nemo adipisci iusto!
                        </p>
                        <div className="inline-flex w-full justify-center mx-auto mt-6">
                            <a href="#" className="btn">Sign Up</a>
                        </div>
                    </div>
                </section>
                <section>
                    <div className="container px-6 py-10 mx-auto">
                        <h1 className="text-2xl font-semibold text-center text-gray-800 capitalize lg:text-3xl dark:text-white">
                            explore
                            our <br /> awesome <span className="underline decoration-green-400">Features</span>
                        </h1>
                        <div className="grid grid-cols-1 mt-8 xl:mt-12">
                            <div className="flex flex-col items-center p-6 space-y-3 text-center border border-neutral-900 dark:border-neutral-800">
                                <div className="flex justify-center items-center">
                                    <span className="inline-block border border-green-400 dark:border-neutral-800 p-3 text-green-400 dark:text-white bg-green-100 dark:bg-green-400">
                                        <IoAlertCircleOutline className="w-6 h-6" />
                                    </span>
                                    <div className="flex items-center h-full px-3 border-y border-r border-neutral-900 dark:border-neutral-800">
                                        <h3 className="text-xl text-gray-700 capitalize dark:text-white">
                                            Important feature
                                        </h3>
                                    </div>
                                </div>
                                <p className="text-gray-500 dark:text-gray-300">
                                    Lorem ipsum dolor sit amet consectetur adipisicing elit.
                                    Provident ab nulla quod dignissimos vel non corrupti doloribus
                                    voluptatum eveniet
                                </p>
                                <a
                                    href="#"
                                    className="flex items-center -mx-1 text-sm text-green-400 capitalize transition-colors duration-300 transform hover:underline hover:text-green-600"
                                >
                                    <span className="mx-1">read more</span>
                                </a>
                            </div>
                            <div className="flex flex-col items-center p-6 space-y-3 text-center border-x border-b border-neutral-900 dark:border-neutral-800">
                                <div className="flex justify-center items-center">
                                    <span className="inline-block border border-green-400 dark:border-neutral-800 p-3 text-green-400 dark:text-white bg-green-100 dark:bg-green-400">
                                        <IoAlertCircleOutline className="w-6 h-6" />
                                    </span>
                                    <div className="flex items-center h-full px-3 border-y border-r border-neutral-900 dark:border-neutral-800">
                                        <h3 className="text-xl text-gray-700 capitalize dark:text-white">
                                            Important feature
                                        </h3>
                                    </div>
                                </div>
                                <p className="text-gray-500 dark:text-gray-300">
                                    Lorem ipsum dolor sit amet consectetur adipisicing elit.
                                    Provident ab nulla quod dignissimos vel non corrupti doloribus
                                    voluptatum eveniet
                                </p>
                                <a
                                    href="#"
                                    className="flex items-center -mx-1 text-sm text-green-400 capitalize transition-colors duration-300 transform hover:underline hover:text-green-600"
                                >
                                    <span className="mx-1">read more</span>
                                </a>
                            </div>
                            <div className="flex flex-col items-center p-6 space-y-3 text-center border-x border-b border-neutral-900 dark:border-neutral-800">
                                <div className="flex justify-center items-center">
                                    <span className="inline-block border border-green-400 dark:border-neutral-800 p-3 text-green-400 dark:text-white bg-green-100 dark:bg-green-400">
                                        <IoAlertCircleOutline className="w-6 h-6" />
                                    </span>
                                    <div className="flex items-center h-full px-3 border-y border-r border-neutral-900 dark:border-neutral-800">
                                        <h3 className="text-xl text-gray-700 capitalize dark:text-white">
                                            Important feature
                                        </h3>
                                    </div>
                                </div>
                                <p className="text-gray-500 dark:text-gray-300">
                                    Lorem ipsum dolor sit amet consectetur adipisicing elit.
                                    Provident ab nulla quod dignissimos vel non corrupti doloribus
                                    voluptatum eveniet
                                </p>
                                <a
                                    href="#"
                                    className="flex items-center -mx-1 text-sm text-green-400 capitalize transition-colors duration-300 transform hover:underline hover:text-green-600"
                                >
                                    <span className="mx-1">read more</span>
                                </a>
                            </div>
                        </div>
                    </div>
                </section>
                <section className="flex items-center flex-1">
                    <div className="flex flex-col w-full px-6">
                        <h5 className="text-5xl font-extrabold text-center lg:text-5xl">
                            <span>Coming Soon</span>
                        </h5>
                        <p className="max-w-3xl mx-auto mt-6 text-lg text-center text-gray-700 dark:text-white md:text-xl">
                            Lorem ipsum dolor sit amet
                            consectetur adipisicing elit. Fugit alias nihil incidunt.
                        </p>
                        <div className="flex flex-col justify-center items-center mt-8 mb-8 space-y-3 sm:-mx-2 sm:flex-row sm:justify-center sm:space-y-0">
                            <input
                                type="text"
                                placeholder="Email Address"
                                className="input input-bordered w-full max-w-xs rounded-none"
                            />
                            <button className="btn rounded-none">Notify Me</button>
                        </div>
                    </div>
                </section>
            </section>
        </main>
    );
}
