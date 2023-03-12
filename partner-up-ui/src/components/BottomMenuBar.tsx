import React from 'react';
import { IoAddOutline, IoAlbumsOutline, IoHomeOutline } from 'react-icons/all';

export default function BottomMenuBar() {
    return (
        <div className="w-full sticky top-[100vh] flex justify-center items-center h-14 border-t border-t-neutral-900 dark:border-t-neutral-800">
            <button className="flex justify-center items-center hover:bg-base-300 gap-1 p-2">
                        <span className="inline-flex justify-center items-center">
                            <IoAlbumsOutline className="w-6 h-6" />
                        </span>
            </button>
            <button
                disabled
                className="flex justify-center items-center bg-green-100 text-green-400 dark:bg-base-300 dark:text-green-400 gap-1 p-2"
            >
                        <span className="inline-flex justify-center items-center">
                            <IoHomeOutline className="w-6 h-6" />
                        </span>
                <span>
                            Home
                        </span>
            </button>
            <button className="flex justify-center items-center hover:bg-base-300 gap-1 p-2">
                        <span className="inline-flex justify-center items-center">
                            <IoAddOutline className="w-6 h-6" />
                        </span>
            </button>
        </div>
    );
}
