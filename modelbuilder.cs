    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atribuicao>(entity =>
        {
            entity.HasKey(e => e.IdAtribuicao);

            entity.ToTable("Atribuicao", "catalogo");

            entity.HasIndex(e => new { e.IdItemCatalogo, e.Descricao }, "UN_Atribuicao_Descricao").IsUnique();

            entity.Property(e => e.Descricao)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AtribuicaoRamal>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AtribuicaoRamal", "catalogo");

            entity.Property(e => e.Ramal)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AutorizacaoItemCatalogo>(entity =>
        {
            entity.HasKey(e => e.IdAutorizacao);

            entity.ToTable("AutorizacaoItemCatalogo", "catalogo");

            entity.HasIndex(e => new { e.UsuarioId, e.IdOrgaoSrh }, "IX_AutorizacaoItemCatalogo_UsuarioId_IdOrgaoSRH").IsUnique();

            entity.Property(e => e.IdOrgaoSrh).HasColumnName("IdOrgaoSRH");
        });

        modelBuilder.Entity<Contato>(entity =>
        {
            entity.HasKey(e => e.IdContato);

            entity.ToTable("Contato", "catalogo");

            entity.HasIndex(e => e.Matricula2, "UN_Contato_Matricula2").IsUnique();

            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Matricula2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Ramal)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Estagiario>(entity =>
        {
            entity.ToTable("Estagiarios", "catestag");

            entity.HasIndex(e => e.NucleoId, "IX_Estagiarios_NucleoId");

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.HasOne(d => d.Nucleo).WithMany(p => p.Estagiarios).HasForeignKey(d => d.NucleoId);
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.ToTable("Horarios", "catestag");

            entity.HasIndex(e => new { e.EstagiarioId, e.DiaDaSemana }, "IX_Horarios_EstagiarioId_DiaDaSemana").IsUnique();

            entity.HasOne(d => d.Estagiario).WithMany(p => p.Horarios).HasForeignKey(d => d.EstagiarioId);
        });

        modelBuilder.Entity<ImagemItemCatalogo>(entity =>
        {
            entity.HasKey(e => e.IdItemCatalogo);

            entity.ToTable("ImagemItemCatalogo", "catalogo");

            entity.Property(e => e.IdItemCatalogo).ValueGeneratedNever();
            entity.Property(e => e.ContentType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemCatalogo>(entity =>
        {
            entity.HasKey(e => e.IdItemCatalogo);

            entity.ToTable("ItemCatalogo", "catalogo");

            entity.HasIndex(e => e.IdOrgaoSrh, "UN_ItemCatalogo_IdOrgaoSRH").IsUnique();

            entity.Property(e => e.AtribuicoesTitular)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.ContatoCorreioEletronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContatoUrl)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Descricao).IsUnicode(false);
            entity.Property(e => e.Estrutura).IsUnicode(false);
            entity.Property(e => e.HorarioAtendimento)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.HorarioFuncionamento)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IdOrgaoSrh).HasColumnName("IdOrgaoSRH");
            entity.Property(e => e.Matricula2Substituto)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("Parte principal da matrícula do substituto cadastrado para ser exibido ao invés do padrão do SRH");
            entity.Property(e => e.Matricula2Titular)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("Parte principal da matrícula do titular cadastrado para ser exibido ao invés do padrão do SRH");
            entity.Property(e => e.NormaAtribuicoesUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.NormaInstituicaoUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Observacao)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Regramento).IsUnicode(false);
            entity.Property(e => e.ResponsavelAtendimento)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Local>(entity =>
        {
            entity.HasKey(e => e.IdLocal);

            entity.ToTable("Local", "catalogo");

            entity.HasIndex(e => e.Nome, "UN_Local_Nome").IsUnique();

            entity.Property(e => e.HorarioFuncionamento)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Nucleo>(entity =>
        {
            entity.HasKey(e => e.IdNucleo);

            entity.ToTable("Nucleos", "catalogo");

            entity.Property(e => e.Descricao)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.IdOrgaoSrh).HasColumnName("IdOrgaoSRH");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Sigla)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.IdPessoa);

            entity.ToTable("Pessoas", "catalogo");

            entity.HasIndex(e => e.NucleoId, "IX_Pessoas_NucleoId");

            entity.HasOne(d => d.Nucleo).WithMany(p => p.Pessoas).HasForeignKey(d => d.NucleoId);
        });

        modelBuilder.Entity<Ramal>(entity =>
        {
            entity.HasKey(e => e.Ramal1);

            entity.ToTable("Ramal", "catalogo");

            entity.Property(e => e.Ramal1)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Ramal");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.IdSede);

            entity.ToTable("Sede", "catalogo");

            entity.HasIndex(e => new { e.Apelido, e.Complemento }, "UK_Sede_Apelido_Complemento").IsUnique();

            entity.Property(e => e.Apelido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cep)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CEP");
            entity.Property(e => e.Complemento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Logradouro)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Municipio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TelefoneInstitucional>(entity =>
        {
            entity.HasKey(e => e.IdTelefone).HasName("PK_Telefone");

            entity.ToTable("TelefoneInstitucional", "catalogo");

            entity.HasIndex(e => new { e.IdItemCatalogo, e.Telefone }, "UN_TelefoneInstitucional_Telefone").IsUnique();

            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TelefoneLocal>(entity =>
        {
            entity.HasKey(e => e.IdTelefoneLocal);

            entity.ToTable("TelefoneLocal", "catalogo");

            entity.HasIndex(e => e.Telefone, "UN_TelefoneLocal").IsUnique();

            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }
