let drawLine = (context, x1, y1, x2, y2, strokeStyle) => {
  context.beginPath();
  context.moveTo(x1, y1);
  context.lineTo(x2, y2);
  context.strokeStyle = strokeStyle || "black";
  context.stroke();
  context.closePath();
}
let drawLines = (board, segments) => {
  let context = board.getContext('2d');
  for (let i = 0; i < segments.length; i += 1) {
    let segment = segments[i];
    drawLine(context, segment.start.x, segment.start.y, segment.end.x, segment.end.y)
  }
}

export { drawLines };