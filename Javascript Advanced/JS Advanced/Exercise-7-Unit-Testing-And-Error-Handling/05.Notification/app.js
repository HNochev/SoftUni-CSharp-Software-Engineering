function notify(message) {
  let notificationDiv = document.getElementById('notification');
  notificationDiv.textContent = message;
  notificationDiv.style.display = 'block';

  let dataNotificationAttribute = notificationDiv.getAttribute('data-notifications-set');
  if (dataNotificationAttribute !== 'true') {
    notificationDiv.setAttribute('data-notifications-set', 'true');
    notificationDiv.addEventListener('click', notificationDivClickHandler);
  }

  function notificationDivClickHandler(e) {
    let notificationDiv = document.getElementById('notification');
    notificationDiv.style.display = 'none';
  }
}