const WebSocket = require('ws');

const server = new WebSocket.Server({ port: 5000 });

server.on('connection', function connect(myself  ) {
    myself.on("message", function incoming(data) {
        server.clients.forEach(function each(client) {
            if (client !== myself && client.readyState === WebSocket.OPEN) {
                client.send(data)
            }
        })
    })
});