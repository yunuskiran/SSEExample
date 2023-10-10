import React, { useEffect, useState } from 'react';

const EventStreamComponent = () => {
    const [sseData, setSSEData] = useState({ message: '', timestamp: '' });

    useEffect(() => {
        const eventSource = new EventSource('/weatherforecast/eventstream');

        eventSource.onmessage = (event) => {
            const eventData = JSON.parse(event.data);
            setSSEData(eventData); // Update the state with SSE data
        };

        eventSource.onerror = (error) => {
            console.error('SSE Error:', error);
        };

        return () => {
            eventSource.close();
        };
    }, []);

    return (
        <div>
            <h1>SSE Data:</h1>
            <p>Message: {sseData.message}</p>
            <p>Timestamp: {sseData.timestamp}</p>
        </div>
    );
};

export default EventStreamComponent;
