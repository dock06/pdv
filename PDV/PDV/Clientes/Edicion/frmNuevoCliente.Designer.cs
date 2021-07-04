namespace PDV.Clientes.Edicion
{
    partial class frmNuevoCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtApMaterno = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.txtApPaterno = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rbtMoral = new System.Windows.Forms.RadioButton();
            this.rbtFisica = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rbtCreditoNo = new System.Windows.Forms.RadioButton();
            this.rbtCreditoSi = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.grpCredito = new System.Windows.Forms.GroupBox();
            this.rbtLimitado = new System.Windows.Forms.RadioButton();
            this.rbtnLibre = new System.Windows.Forms.RadioButton();
            this.txtCredito = new System.Windows.Forms.TextBox();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.txtDisponible = new System.Windows.Forms.TextBox();
            this.btnDisponible = new System.Windows.Forms.Button();
            this.pnlContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpCredito.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.panel1);
            this.pnlContainer.Controls.Add(this.pnlDetail);
            this.pnlContainer.Controls.Add(this.pnlEncabezado);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(864, 449);
            this.pnlContainer.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 50);
            this.panel1.TabIndex = 5;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.Snow;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::PDV.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(738, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(110, 32);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.tabControl1);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetail.Location = new System.Drawing.Point(0, 51);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(864, 348);
            this.pnlDetail.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpGeneral);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 348);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.btnDisponible);
            this.tbpGeneral.Controls.Add(this.txtDisponible);
            this.tbpGeneral.Controls.Add(this.lblDisponible);
            this.tbpGeneral.Controls.Add(this.label11);
            this.tbpGeneral.Controls.Add(this.label5);
            this.tbpGeneral.Controls.Add(this.label10);
            this.tbpGeneral.Controls.Add(this.txtCorreo);
            this.tbpGeneral.Controls.Add(this.label9);
            this.tbpGeneral.Controls.Add(this.txtApMaterno);
            this.tbpGeneral.Controls.Add(this.label8);
            this.tbpGeneral.Controls.Add(this.txtRFC);
            this.tbpGeneral.Controls.Add(this.txtApPaterno);
            this.tbpGeneral.Controls.Add(this.label7);
            this.tbpGeneral.Controls.Add(this.label4);
            this.tbpGeneral.Controls.Add(this.txtContacto);
            this.tbpGeneral.Controls.Add(this.label3);
            this.tbpGeneral.Controls.Add(this.txtTelefono);
            this.tbpGeneral.Controls.Add(this.label2);
            this.tbpGeneral.Controls.Add(this.txtDireccion);
            this.tbpGeneral.Controls.Add(this.label1);
            this.tbpGeneral.Controls.Add(this.btnGuardar);
            this.tbpGeneral.Controls.Add(this.button1);
            this.tbpGeneral.Controls.Add(this.label6);
            this.tbpGeneral.Controls.Add(this.txtNombre);
            this.tbpGeneral.Controls.Add(this.lblCodigo);
            this.tbpGeneral.Controls.Add(this.txtCodigo);
            this.tbpGeneral.Controls.Add(this.groupBox1);
            this.tbpGeneral.Controls.Add(this.groupBox2);
            this.tbpGeneral.Controls.Add(this.grpCredito);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 26);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral.Size = new System.Drawing.Size(856, 318);
            this.tbpGeneral.TabIndex = 1;
            this.tbpGeneral.Text = "Información General";
            this.tbpGeneral.UseVisualStyleBackColor = true;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(539, 164);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(305, 29);
            this.txtCorreo.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(455, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 21);
            this.label9.TabIndex = 58;
            this.label9.Text = "Correo:";
            // 
            // txtApMaterno
            // 
            this.txtApMaterno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApMaterno.Location = new System.Drawing.Point(147, 164);
            this.txtApMaterno.Name = "txtApMaterno";
            this.txtApMaterno.Size = new System.Drawing.Size(293, 29);
            this.txtApMaterno.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 21);
            this.label8.TabIndex = 56;
            this.label8.Text = "Ap. Materno:";
            // 
            // txtRFC
            // 
            this.txtRFC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFC.Location = new System.Drawing.Point(539, 198);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(305, 29);
            this.txtRFC.TabIndex = 11;
            // 
            // txtApPaterno
            // 
            this.txtApPaterno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApPaterno.Location = new System.Drawing.Point(147, 129);
            this.txtApPaterno.Name = "txtApPaterno";
            this.txtApPaterno.Size = new System.Drawing.Size(293, 29);
            this.txtApPaterno.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 21);
            this.label7.TabIndex = 53;
            this.label7.Text = "Ap. Paterno:";
            // 
            // rbtMoral
            // 
            this.rbtMoral.AutoSize = true;
            this.rbtMoral.Location = new System.Drawing.Point(137, 13);
            this.rbtMoral.Name = "rbtMoral";
            this.rbtMoral.Size = new System.Drawing.Size(128, 25);
            this.rbtMoral.TabIndex = 1;
            this.rbtMoral.Text = "Persona Moral";
            this.rbtMoral.UseVisualStyleBackColor = true;
            this.rbtMoral.CheckedChanged += new System.EventHandler(this.rbtMoral_CheckedChanged);
            // 
            // rbtFisica
            // 
            this.rbtFisica.AutoSize = true;
            this.rbtFisica.Checked = true;
            this.rbtFisica.Location = new System.Drawing.Point(6, 13);
            this.rbtFisica.Name = "rbtFisica";
            this.rbtFisica.Size = new System.Drawing.Size(125, 25);
            this.rbtFisica.TabIndex = 0;
            this.rbtFisica.TabStop = true;
            this.rbtFisica.Text = "Persona Fisica";
            this.rbtFisica.UseVisualStyleBackColor = true;
            this.rbtFisica.CheckedChanged += new System.EventHandler(this.rbtFisica_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(455, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 21);
            this.label4.TabIndex = 49;
            this.label4.Text = "Contacto";
            // 
            // txtContacto
            // 
            this.txtContacto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContacto.Location = new System.Drawing.Point(539, 129);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(305, 29);
            this.txtContacto.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(455, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 21);
            this.label3.TabIndex = 47;
            this.label3.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(539, 94);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(305, 29);
            this.txtTelefono.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(455, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 45;
            this.label2.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(539, 59);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(305, 29);
            this.txtDireccion.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(455, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 21);
            this.label1.TabIndex = 42;
            this.label1.Text = "RFC:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Snow;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::PDV.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(734, 232);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 32);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Snow;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::PDV.Properties.Resources.limpiar2;
            this.button1.Location = new System.Drawing.Point(618, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 32);
            this.button1.TabIndex = 12;
            this.button1.Text = "Limpiar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 21);
            this.label6.TabIndex = 41;
            this.label6.Text = "Nombre: ";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(147, 94);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(293, 29);
            this.txtNombre.TabIndex = 1;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(31, 28);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(63, 21);
            this.lblCodigo.TabIndex = 39;
            this.lblCodigo.Text = "Código:";
            this.lblCodigo.Visible = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(147, 24);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(293, 29);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.Visible = false;
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.White;
            this.pnlEncabezado.BackgroundImage = global::PDV.Properties.Resources.fondo1;
            this.pnlEncabezado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(864, 51);
            this.pnlEncabezado.TabIndex = 3;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(11, 7);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(144, 30);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Nuevo Cliente";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 21);
            this.label10.TabIndex = 59;
            this.label10.Text = "Aplica Credito:";
            // 
            // rbtCreditoNo
            // 
            this.rbtCreditoNo.AutoSize = true;
            this.rbtCreditoNo.Checked = true;
            this.rbtCreditoNo.Location = new System.Drawing.Point(6, 13);
            this.rbtCreditoNo.Name = "rbtCreditoNo";
            this.rbtCreditoNo.Size = new System.Drawing.Size(49, 25);
            this.rbtCreditoNo.TabIndex = 0;
            this.rbtCreditoNo.TabStop = true;
            this.rbtCreditoNo.Text = "No";
            this.rbtCreditoNo.UseVisualStyleBackColor = true;
            this.rbtCreditoNo.CheckedChanged += new System.EventHandler(this.rbtCreditoNo_CheckedChanged);
            // 
            // rbtCreditoSi
            // 
            this.rbtCreditoSi.AutoSize = true;
            this.rbtCreditoSi.Location = new System.Drawing.Point(61, 13);
            this.rbtCreditoSi.Name = "rbtCreditoSi";
            this.rbtCreditoSi.Size = new System.Drawing.Size(41, 25);
            this.rbtCreditoSi.TabIndex = 1;
            this.rbtCreditoSi.Text = "Si";
            this.rbtCreditoSi.UseVisualStyleBackColor = true;
            this.rbtCreditoSi.CheckedChanged += new System.EventHandler(this.rbtCreditoSi_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtFisica);
            this.groupBox1.Controls.Add(this.rbtMoral);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(147, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 41);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 21);
            this.label5.TabIndex = 63;
            this.label5.Text = "Tipo Cliente:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtCreditoNo);
            this.groupBox2.Controls.Add(this.rbtCreditoSi);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(147, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 41);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(31, 234);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 21);
            this.label11.TabIndex = 66;
            this.label11.Text = "Tipo Crédito:";
            // 
            // grpCredito
            // 
            this.grpCredito.Controls.Add(this.txtCredito);
            this.grpCredito.Controls.Add(this.rbtLimitado);
            this.grpCredito.Controls.Add(this.rbtnLibre);
            this.grpCredito.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCredito.Location = new System.Drawing.Point(147, 221);
            this.grpCredito.Name = "grpCredito";
            this.grpCredito.Size = new System.Drawing.Size(293, 41);
            this.grpCredito.TabIndex = 5;
            this.grpCredito.TabStop = false;
            // 
            // rbtLimitado
            // 
            this.rbtLimitado.AutoSize = true;
            this.rbtLimitado.Checked = true;
            this.rbtLimitado.Location = new System.Drawing.Point(6, 13);
            this.rbtLimitado.Name = "rbtLimitado";
            this.rbtLimitado.Size = new System.Drawing.Size(89, 25);
            this.rbtLimitado.TabIndex = 0;
            this.rbtLimitado.TabStop = true;
            this.rbtLimitado.Text = "Limitado";
            this.rbtLimitado.UseVisualStyleBackColor = true;
            this.rbtLimitado.CheckedChanged += new System.EventHandler(this.rbtLimitado_CheckedChanged);
            // 
            // rbtnLibre
            // 
            this.rbtnLibre.AutoSize = true;
            this.rbtnLibre.Location = new System.Drawing.Point(198, 14);
            this.rbtnLibre.Name = "rbtnLibre";
            this.rbtnLibre.Size = new System.Drawing.Size(89, 25);
            this.rbtnLibre.TabIndex = 2;
            this.rbtnLibre.Text = "Ilimitado";
            this.rbtnLibre.UseVisualStyleBackColor = true;
            this.rbtnLibre.CheckedChanged += new System.EventHandler(this.rbtnLibre_CheckedChanged);
            // 
            // txtCredito
            // 
            this.txtCredito.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredito.Location = new System.Drawing.Point(101, 13);
            this.txtCredito.Name = "txtCredito";
            this.txtCredito.Size = new System.Drawing.Size(91, 25);
            this.txtCredito.TabIndex = 1;
            this.txtCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDisponible
            // 
            this.lblDisponible.AutoSize = true;
            this.lblDisponible.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponible.Location = new System.Drawing.Point(31, 269);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Size = new System.Drawing.Size(87, 21);
            this.lblDisponible.TabIndex = 67;
            this.lblDisponible.Text = "Disponible:";
            this.lblDisponible.Visible = false;
            // 
            // txtDisponible
            // 
            this.txtDisponible.BackColor = System.Drawing.SystemColors.Control;
            this.txtDisponible.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisponible.Location = new System.Drawing.Point(147, 265);
            this.txtDisponible.Name = "txtDisponible";
            this.txtDisponible.ReadOnly = true;
            this.txtDisponible.Size = new System.Drawing.Size(177, 29);
            this.txtDisponible.TabIndex = 68;
            this.txtDisponible.Visible = false;
            // 
            // btnDisponible
            // 
            this.btnDisponible.BackColor = System.Drawing.Color.Snow;
            this.btnDisponible.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisponible.Image = global::PDV.Properties.Resources.buscar;
            this.btnDisponible.Location = new System.Drawing.Point(330, 263);
            this.btnDisponible.Name = "btnDisponible";
            this.btnDisponible.Size = new System.Drawing.Size(110, 32);
            this.btnDisponible.TabIndex = 6;
            this.btnDisponible.Text = "Detalle";
            this.btnDisponible.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDisponible.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDisponible.UseVisualStyleBackColor = false;
            this.btnDisponible.Visible = false;
            // 
            // frmNuevoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(864, 449);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNuevoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Cliente";
            this.Load += new System.EventHandler(this.frmNuevaPresentacion_Load);
            this.pnlContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.tbpGeneral.PerformLayout();
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpCredito.ResumeLayout(false);
            this.grpCredito.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.RadioButton rbtMoral;
        private System.Windows.Forms.RadioButton rbtFisica;
        private System.Windows.Forms.TextBox txtApPaterno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtApMaterno;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbtCreditoSi;
        private System.Windows.Forms.RadioButton rbtCreditoNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grpCredito;
        private System.Windows.Forms.TextBox txtCredito;
        private System.Windows.Forms.RadioButton rbtLimitado;
        private System.Windows.Forms.RadioButton rbtnLibre;
        private System.Windows.Forms.Label lblDisponible;
        private System.Windows.Forms.Button btnDisponible;
        private System.Windows.Forms.TextBox txtDisponible;
    }
}