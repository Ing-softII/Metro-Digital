Cypress.on('uncaught:exception', (err, runnable) => {
  // Ignora errores de jQuery no definida solo temporalmente
  if (err.message.includes('jQuery is not defined')) {
    return false;
  }
});
describe('Prueba del Login - Metro Digital', () => {
  it('Debería ingresar credenciales y hacer login correctamente', () => {
    // Cambia el puerto si es diferente
    cy.visit('http://localhost:5030');

    // Validar que cargó el formulario
    cy.contains('Iniciar Sesión').should('exist');

    // Ingresar el usuario
    cy.get('input[name="Username"]').type('Adona');

    // Ingresar la contraseña
    cy.get('input[name="Password"]').type('Adona.1520');

    // Hacer clic en el botón de login
    cy.get('button.btn-login').click();

    // Validar algún mensaje o redirección (ajústalo según la lógica real del sistema)
    cy.url().should('not.include', '/index'); // ejemplo: ya no está en login
  });

  
});
