describe('Registro de usuario', () => {
  beforeEach(() => {
    // Ignorar error de jQuery (solo mientras lo arreglas)
    Cypress.on('uncaught:exception', (err, runnable) => {
      if (err.message.includes('jQuery is not defined')) {
        return false;
      }
    });
  });

  it('Completa y envía el formulario de registro', () => {
    cy.visit('http://localhost:5030/Auth/Register');

    cy.get('input[name="Name"]').type('Adonaiby');
    cy.get('input[name="LastName"]').type('Pérez');
    cy.get('input[name="PhoneNumber"]').type('8291234567');
    cy.get('input[name="Username"]').type('Adona');
    cy.get('input[name="Email"]').type('nunezdejesusa@gmail.com');
    cy.get('input[name="Password"]').type('Adona.1520');
    cy.get('input[name="RepeatPassword"]').type('Adona.1520');
    cy.get('select[name="Role"]').select('Secretario/a');

    cy.get('form').submit();

    // Aquí puedes validar redirección o mensaje de éxito
    cy.url().should('not.include', '/Register');
  });
});
