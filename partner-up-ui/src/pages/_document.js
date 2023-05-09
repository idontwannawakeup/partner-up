import { Head, Html, Main, NextScript } from 'next/document';
import React from 'react';

export default function Document() {
    return (
        <Html lang="en">
            <Head />
            <body className="light" data-theme="lofi">
                <Main />
                <NextScript />
            </body>
        </Html>
    );
}
