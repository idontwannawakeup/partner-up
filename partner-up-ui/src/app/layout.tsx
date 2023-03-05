import React from 'react';
import './globals.css';

export const metadata = {
    title: 'Partner Up',
    description: 'WIP',
};

export default function RootLayout({ children }: {
    children: React.ReactNode
}) {
    return (
        <html lang="en">
        <body>{children}</body>
        </html>
    );
}