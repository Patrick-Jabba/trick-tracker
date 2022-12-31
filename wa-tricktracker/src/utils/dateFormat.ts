const functions = {
  formatDateAndTimeToString: function(date: Date) {
    const dateFormated = new Date(date);

    return dateFormated.toLocaleString().substring(0, 16);
  }
}

export default functions;